using DoAnTKPMNC.Entities;
using DoAnTKPMNC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoAnTKPMNC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfStoreController : ControllerBase
    {
        TKPMNCContext _context;
        public TypeOfStoreController(TKPMNCContext context)
        {
            _context = context;
        }
        // GET: api/<TypeOfStoreController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TypeOfStores.ToList());
        }

        // GET api/<TypeOfStoreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var typeOfStore= _context.TypeOfStores.FirstOrDefault(s=>s.Equals(id));
            if (typeOfStore == null)
            {
                return NotFound();
            }
            return Ok(typeOfStore);
        }

        // POST api/<TypeOfStoreController>
        [HttpPost]
        public IActionResult Post(TypeOfStoreModel typeOfStoreModel)
        {
            if(typeOfStoreModel == null)
            {
                return BadRequest();
            }
            TypeOfStore type=new TypeOfStore();
            type.TypeId = NextID();
            type.Description= typeOfStoreModel.Description;
            _context.TypeOfStores.Add(type);
            _context.SaveChanges();

            return Ok();
        }
        private dynamic NextID()
        {
            if (_context.TypeOfStores.Count() <= 0) return 0;
            return _context.TypeOfStores.Max(s => s.TypeId) + 1;
        } 

        // PUT api/<TypeOfStoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TypeOfStoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
