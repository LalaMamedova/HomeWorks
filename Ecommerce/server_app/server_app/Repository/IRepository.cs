using Microsoft.AspNetCore.Mvc;

namespace server_app.Repository
{
    public interface IRepository<T>
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> Get(int id);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Create([FromBody] T model);
        Task<IActionResult> Update([FromBody]T model, int id);
    }
}
