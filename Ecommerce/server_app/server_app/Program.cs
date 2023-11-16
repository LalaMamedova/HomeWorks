using AutoMapper;
using DeviceLib.Model.Class.Device;
using DeviceLib.Model.Class.DTO.DeviceDTO;
using DeviceLib.Seed;
using Microsoft.EntityFrameworkCore;
using server_app.Contoller;
using server_app.DatabaseContext;
using server_app.Helper;
using server_app.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(ops => ops.AddPolicy("AllowAnyOrigins", builder => builder.AllowAnyOrigin()));

builder.Services.AddDbContext<EcommerceDb>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString"]);
});


//builder.Services.AddScoped<IRepository<CharacteristicTypeDTO>, CharacteristicTypeController>();
builder.Services.AddScoped<IRepository<Brand>, BrandController>();
builder.Services.AddScoped<IRepository<CategoryDTO>, CategoryController>();
builder.Services.AddScoped<IRepository<ProductDTO>, ProductController>();
builder.Services.AddScoped<AutoMapperConfig>();
builder.Services.AddScoped<Seed>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAnyOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();

app.Run();

