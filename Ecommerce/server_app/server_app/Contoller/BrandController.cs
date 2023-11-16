using DeviceLib.Model.Class.Device;
using Microsoft.AspNetCore.Mvc;
using server_app.DatabaseContext;
using server_app.Repository;

namespace server_app.Contoller;
[Route("api/v1/[controller]")]
[ApiController()]
public class BrandController:ControllerBase,IRepository<Brand>
{
    private EcommerceDb _db;
    private readonly CrudService<Brand> _crud;

    public BrandController(EcommerceDb db)
    {
        _db = db;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_db.Brand);
    }

    [HttpGet("Get/{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(_db.Brand.Where(x => x.Id == id).FirstOrDefault());

    }

    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(_db.Brand.Remove(_db.Brand.Where(x => x.Id == id).FirstOrDefault()));
    }


    [HttpPost("Post")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] Brand model)
    {
        if (model == null)
            return BadRequest(ModelState);

        var result = _crud.Post(model);
        _db.SaveChanges();

        return Ok("Successfully created");
    }


    [HttpPut("Upadate/{id:int}")]
    public async Task<IActionResult> Update([FromBody] Brand model, int id)
    {
        var old = _db.Brand.Where(x => x.Id == model.Id).FirstOrDefault();
        old = model;
        return Ok(model);

    }


}
