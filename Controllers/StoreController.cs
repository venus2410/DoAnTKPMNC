using DoAnTKPMNC.Entities;
using DoAnTKPMNC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoAnTKPMNC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        TKPMNCContext _context;
        public StoreController(TKPMNCContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Stores.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var store = _context.Stores.SingleOrDefault(s=>s.StoreId.Equals(id)&&s.IsDeleted==false);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        // POST api/<StoreController>
        [HttpPost]
        public IActionResult Post(StoreModel storeModel)
        {
            var isTypeIdExist=_context.TypeOfStores.FirstOrDefault(t=>t.TypeId==storeModel.TypeId);
            if(isTypeIdExist==null)
            {
                return NotFound("Not found type id");
            }
            var isPartnerIdExist=_context.Partners.FirstOrDefault(p=>p.PartnerId==storeModel.PartnerId);
            if(isPartnerIdExist==null)
            {
                return NotFound("Partner id not exist");
            }
            Store store = new Store();
            store.StoreId = NextStoreId();
            store.TypeId=storeModel.TypeId;
            store.Address=storeModel.Address;
            store.PartnerId=storeModel.PartnerId;
            store.StoredName=storeModel.StoredName;
            
            _context.Stores.Add(store);
            _context.SaveChanges();
            return Ok(store);
        }
        dynamic NextStoreId()
        {
            var count = _context.Stores.Count();
            if (count > 0)
            {
                return _context.Stores.Max(s => s.StoreId) + 1;
            }
            return 1;
        }
        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(StoreModel storeModel,int storeId)
        {
            var isTypeIdExist = _context.TypeOfStores.FirstOrDefault(t => t.TypeId == storeModel.TypeId);
            if (isTypeIdExist == null)
            {
                return NotFound("Not found type id");
            }
            var isPartnerIdExist = _context.Partners.FirstOrDefault(p => p.PartnerId == storeModel.PartnerId);
            if (isPartnerIdExist == null)
            {
                return NotFound("Partner id not exist");
            }
            var store = _context.Stores.FirstOrDefault(s => s.StoreId == storeId);
            if (store == null)
            {
                return NotFound("Store not found");
            }

            store.StoreId = NextStoreId();
            store.TypeId = storeModel.TypeId;
            store.Address = storeModel.Address;
            store.PartnerId = storeModel.PartnerId;
            store.StoredName = storeModel.StoredName;

            _context.SaveChanges();

            return Ok(store);
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var store = _context.Stores.FirstOrDefault(s=>s.StoreId== id);
            if (store == null) { return BadRequest("Not Found Store"); }
            store.IsDeleted= true;
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
