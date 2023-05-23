using DoAnTKPMNC.Entities;
using DoAnTKPMNC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoAnTKPMNC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        private TKPMNCContext _context;
        public CustomerController(TKPMNCContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Customers.Where(c=>c.IsDeleted==false).ToList());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id && c.IsDeleted == false);
                if (customer == null) {
                    return BadRequest();
                }
                return Ok(customer);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(CustomerModel customerModel)
        {
            try
            {
                AccountController accountController = new AccountController(_context);
                var account = accountController.Post(customerModel.Account, 3);
                if (account == null)
                {
                    return BadRequest("username already exist");
                }

                Customer customer = new Customer();
                customer.CustomerId=NextCustomerId();
                customer.Name= customerModel.Name;
                customer.Address = customerModel.Address;
                customer.AccountId= account.AccountId;
                customer.Email = customerModel.Email;
                customer.Account= account;
                //customer.IsDeleted=false;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return Ok(customer);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        private int NextCustomerId()
        {
            var count = _context.Customers.Count(); 
            if(count > 0) { 
                return _context.Customers.Max(s => s.CustomerId)+1;
            }
            return 1;
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put()
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
