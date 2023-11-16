using AutoMapper;
using DeviceLib.Model.Class.Device;
using DeviceLib.Model.Class.DTO.DeviceDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_app.DatabaseContext;
using server_app.Repository;

namespace server_app.Contoller;

[Route("api/v1/[controller]")]
[ApiController()]
public class ProductController : ControllerBase, IRepository<ProductDTO>
{
    private readonly IMapper _mapper;
    private readonly EcommerceDb _ecommerceDB;
    private readonly CrudService<Product> _crud;
    public ProductController(EcommerceDb db, IMapper mapper)
    {
        _ecommerceDB = db;
        _mapper = mapper;
        _crud = new(_ecommerceDB.Products.ToList(), _ecommerceDB);

    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var allProducts = _ecommerceDB.Products
                    .Include(x => x.CharacteristicValues)
                    .Include(x=>x.Brand);

        var productsDTO = _mapper.Map<List<ProductDTO>>(allProducts);
        return Ok(productsDTO);
    }


    [HttpGet("Get/{id:int}")]

    public async Task<IActionResult> Get(int id)
    {
        var getProducts = _ecommerceDB.Products
               .Include(x => x.CharacteristicValues)
               .Include(x => x.Brand)
               .FirstOrDefault(x => x.Id == id);

        if (getProducts != null)
        {
            return Ok(getProducts);
        }
        return BadRequest();
    }

    [HttpPut("Upadate/{id:int}")]
    public async Task<IActionResult> Update([FromBody] ProductDTO model, int id)
    {
        try
        {
            var old = _ecommerceDB.Products
               .Include(x => x.CharacteristicValues)
               .Include(x => x.Brand)
               .FirstOrDefault(x => x.Id == id);

            if (old != null)
            {
                _mapper.Map(model, old);
                _ecommerceDB.SaveChanges();
                return Ok(old);
            }
            else
                return NotFound();

        }
        catch (Exception)
        {
            return BadRequest();
        }


    }

    [HttpPost("Post")]
    public async Task<IActionResult> Create([FromBody] ProductDTO model)
    {
        var product = _mapper.Map<Product>(model);
        if (_crud.Post(product))
        {
            return Ok(product);
        }
        return BadRequest();
    }

    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (_crud.Delete(id, x => x.Id))
        {
            return Ok("Value was successfully remove");
        }
        return BadRequest();

    }
}
