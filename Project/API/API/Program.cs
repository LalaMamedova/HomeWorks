using API.Classes;
using API.Classes.TempObj;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
});



var tempTechnologies = new TempTechs();
var technologies = tempTechnologies.Technologies; 
var tempUsers = new TempUsers();
var users = tempUsers.users;

app.UseHttpsRedirection();

app.MapGet("/technologies", () =>
{
    return Results.Ok(technologies);
});
app.MapGet("/technologies/{id}", (int id) =>
{
   var techs = technologies.Find(x => x.id == id);
   if(techs == null)
        return Results.NotFound("Sorry but we can't found it");
    
    return Results.Ok(techs);
});

app.MapGet("/technologies/{name}", (string name) =>
{
    var techs = technologies.Find(x => x.name == name);
    if (techs == null)
        return Results.NotFound("Sorry but we can't found it");

    return Results.Ok(techs);
});

app.MapPost("/technologies", (Technology tech) =>
{
    if (!string.IsNullOrEmpty(tech.name) && !string.IsNullOrEmpty(tech.description) && !string.IsNullOrEmpty(tech.images[0]))
    {
        technologies.Add(tech);
        return Results.Ok(tech);
    }
    return Results.NotFound("Please fill all field");

});

app.MapDelete("/technologies/{id}", (int id) =>
{
    var tech = technologies.Find(x => x.id== id);
    if (tech!=null)
    {
        technologies.Remove(tech);
        return Results.Ok(tech);
    }
    return Results.NotFound("Can't find this tech");

});

app.MapPut("/technologies/{id}", (int id,Technology editTech) =>
{
    var tech = technologies.Find(x => x.id == id);
    if (tech != null)
    {
        tech.name = editTech.name;
        tech.year = editTech.year;
        tech.description = editTech.description;
        tech.charname = editTech.charname;
        tech.charvalue = editTech.charvalue;
        tech.interestingfacts = editTech.interestingfacts;
        tech.type = editTech.type;

        return Results.Ok(tech);
    }
    return Results.NotFound("Can't find this tech");
});


app.MapGet("/users", () =>
{ return users; });

app.MapPost("/users", (Users user) =>
{
    if (!string.IsNullOrEmpty(user.Password) && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Nickname))
    {
        users.Add(user);
        return Results.Ok(user);
    }
    return Results.NotFound("Please fill all field");

});


app.Run();

