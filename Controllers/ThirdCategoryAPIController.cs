using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdCategoryAPIController : ControllerBase
    {
        private readonly IProductTblServices db;

        public ThirdCategoryAPIController(IProductTblServices db)
        {
            this.db = db;
        }
        // GET: api/<ThirdCategoryAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ThirdCategoryAPIController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
           var Data = await db.DropThirdCategory(id);

            return new JsonResult(Data);
        }

        // POST api/<ThirdCategoryAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ThirdCategoryAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThirdCategoryAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
