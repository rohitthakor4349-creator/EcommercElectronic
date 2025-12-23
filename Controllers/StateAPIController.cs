using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StateAPIController : ControllerBase
    {
        private readonly ICityTblServices db;

        public StateAPIController(ICityTblServices db)
        {
            this.db = db;
        }
        // GET: api/<StateAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StateAPIController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
           var Data = await db.DropState(id);

            return new JsonResult(Data);
        }

        // POST api/<StateAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StateAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StateAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
