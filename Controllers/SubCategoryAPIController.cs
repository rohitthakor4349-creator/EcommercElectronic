using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryAPIController : ControllerBase
    {
        private readonly IThirdCategoryTblServices db;

        public SubCategoryAPIController(IThirdCategoryTblServices db)
        {
            this.db = db;
        }
        // GET: api/<SubCategoryAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SubCategoryAPIController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            var Data = await db.DropSubCategory(id);

            return new JsonResult(Data);
        }

        // POST api/<SubCategoryAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SubCategoryAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubCategoryAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
