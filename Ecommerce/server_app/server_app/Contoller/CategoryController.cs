using AutoMapper;
using DeviceLib.Model.Class.Device;
using DeviceLib.Model.Class.DTO.DeviceDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_app.DatabaseContext;
using server_app.Repository;
using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;
using System.Text.Json;
using Humanizer;

namespace server_app.Contoller;

[Route("api/v1/[controller]")]
[ApiController()]


public class CategoryController : ControllerBase,IRepository<CategoryDTO>
{

    private readonly EcommerceDb _ecommerceDb;
    private readonly CrudService<Category> _crudService;
    private readonly IMapper _mapper;
    public CategoryController(EcommerceDb db, IMapper mapper)
    {
        _ecommerceDb = db;
        _mapper = mapper;
        _crudService = new(_ecommerceDb.Categorys.ToList(),_ecommerceDb);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var category = _ecommerceDb.Categorys
            .Include(c => c.SubCategories)
            .ThenInclude(sc => sc.CharacteristicsType)
            .ThenInclude(c=>c.Characteristics).ToList();

        var dto = _mapper.Map<List<CategoryDTO>>(category);   
      
        return Ok(dto);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = _ecommerceDb.Categorys
              .Include(c => c.SubCategories)
              .ThenInclude(sc => sc.CharacteristicsType)
              .ThenInclude(c => c.Characteristics)
              .FirstOrDefault(x=>x.Id==id);

        if(category != null)
        {
            var dto = _mapper.Map<CategoryDTO>(category);
            return Ok(dto);
        }
        return BadRequest();

    }

    [HttpPost("Post")]
    public async Task<IActionResult> Create([FromBody] CategoryDTO model)
    {
        var category = _mapper.Map<Category>(model);
        foreach (var item in category.SubCategories)
        {
            item.Category = new() { Name = model.Name };
        }

        if (_crudService.Post(category))
        {
            return Ok(category);
        }
        return BadRequest();
    }



    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if(_crudService.Delete(id, p => p.Id))
        {
            return Ok("Value was successfully remove");
        }
        return BadRequest();
    }


    [HttpPut("Put/{id}")]
    public async Task<IActionResult> Update([FromBody] CategoryDTO model, int id)
    {
        try
        {
            var old = _ecommerceDb.Categorys
                      .Include(c => c.SubCategories)
                      .ThenInclude(sc => sc.CharacteristicsType)
                      .ThenInclude(c => c.Characteristics)
                      .FirstOrDefault(x => x.Id == id);

            if (old != null)
            {
                _mapper.Map(model, old);
                _ecommerceDb.SaveChanges();
                return Ok(model);
            }
            else
                return NotFound();
            
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }




}
