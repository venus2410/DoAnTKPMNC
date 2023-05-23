using DoAnTKPMNC.Entities;
using DoAnTKPMNC.Models.DoAnTKPMNC.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoAnTKPMNC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private TKPMNCContext _context;
        public PartnerController(TKPMNCContext context)
        {
            _context = context;
        }

        // GET: api/<PartnerController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Partners.Where(p=>p.IsDeleted==false));
        }

        // GET api/<PartnerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Partner rs = _context.Partners.SingleOrDefault(s => s.PartnerId == id&&s.IsDeleted==false);
                if (rs != null)
                {
                    return Ok(rs);
                }
                else { return NotFound("Not found the partner!"); }
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        // POST api/<PartnerController>
        [HttpPost]
        public IActionResult Post(PartnerModel partnerModel)
        {
            // add tao tai khoan
            try
            {

                /*Account account = new Account();
                int accid = NextAccountId();
                account.AccountId = accid;
                account.UserName = partnerModel.AccountModel.UserName;
                account.Password = partnerModel.AccountModel.Password;
                account.RoleId = 2;
                _context.Accounts.Add(account);*/
                AccountController accountController = new AccountController(_context);
                var account = accountController.Post(partnerModel.AccountModel, 2);
                if (account == null)
                {
                    return BadRequest("username already exist");
                }

                Partner partner = new();
                partner.PartnerId = NextPartnerId();
                partner.PhoneNumber = partnerModel.PhoneNumber;
                partner.AccountId = account.AccountId;
                partner.PartnerName = partnerModel.PartnerName;
                partner.Account = new Account();
                partner.Account = account;
                partner.IsDeleted = false;

                _context.Partners.Add(partner);
                _context.SaveChanges();

                return Ok(partner);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private int NextAccountId()
        {
            return _context.Accounts.Max(s => s.AccountId) +1;
        }
        private int NextPartnerId()
        {
            return _context.Partners.Count() + 1;
        }

        // PUT api/<PartnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PartnerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Partner rs = _context.Partners.SingleOrDefault(s => s.PartnerId == id && s.IsDeleted == false);
                if (rs != null)
                {
                    rs.IsDeleted= true;
                    _context.SaveChanges();
                    return Ok();
                }
                else { return NotFound("Not found the partner!"); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
