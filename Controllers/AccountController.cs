using DoAnTKPMNC.Entities;
using DoAnTKPMNC.Models;
using DoAnTKPMNC.Models.DoAnTKPMNC.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoAnTKPMNC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private TKPMNCContext _context;
        public AccountController(TKPMNCContext context)
        {
            _context = context;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Accounts.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Account account = _context.Accounts.FirstOrDefault(s=>s.AccountId==id&&s.IsDeleted==false);
                if(account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AccountController>
        [NonAction]
        public Account Post(AccountModel accountMd, int roleId)
        {
            var isExist=_context.Accounts.FirstOrDefault(a=>a.UserName==accountMd.UserName);
            if(isExist != null)
            {
                return null;
            }
            Account account = new Account();
            int accid = NextAccountId();
            account.AccountId = accid;
            account.UserName = accountMd.UserName;
            account.Password = accountMd.Password;
            account.RoleId = roleId;
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account;
        }
        private int NextAccountId()
        {
            return _context.Accounts.Max(s => s.AccountId) + 1;
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string password)
        {
            try
            {
                Account account =_context.Accounts.FirstOrDefault(s=>s.AccountId== id&&s.IsDeleted==false);
                if(account == null)
                {
                    return NotFound();
                }
                if (account.Password == "")
                {
                    return BadRequest("Password can not be empty");
                }
                account.Password=password;
                _context.SaveChanges();
                return Ok();
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var account = _context.Accounts.FirstOrDefault(a=>a.AccountId==id&&a.IsDeleted==false);
            if(account == null )
            {
                return NotFound();
            }
            else
            {
                account.IsDeleted=true;
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
