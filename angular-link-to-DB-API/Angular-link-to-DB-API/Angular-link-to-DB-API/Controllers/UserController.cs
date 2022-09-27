using Angular_link_to_DB_API.Common;
using Angular_link_to_DB_API.Data;
using Angular_link_to_DB_API.Db;
using Angular_link_to_DB_API.Helpers;
using Angular_link_to_DB_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angular_link_to_DB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        //private readonly DbContent _dbContent;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        private readonly Utils _utils;
        private readonly CadetDbContext _CadetDB;
        private readonly CadetAuditTrailDbContext _CadetAuditTrailDB;

        public UserController(ILogger<UserController> logger, IConfiguration configuration,Utils utils, CadetDbContext cadetDb, CadetAuditTrailDbContext cadetAuditTrailDB)
        {
            _logger = logger;
            _configuration = configuration;
            _utils = utils;
            _CadetDB = cadetDb;
            _CadetAuditTrailDB = cadetAuditTrailDB;
            //_dbContent = dbContent;
        }

        [Route("GetUsers")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            _logger.LogDebug($"{nameof(UserController)}.{nameof(GetUsers)}");

            //var test = _utils.GetUsers();
            var test = _CadetDB.Users.ToList();
            //var test = _CadetDB.Users.FromSql($"EXECUTE dbo.prGetUsers").ToList();
            if(test != null)
            {
                _logger.LogDebug($"{nameof(UserController)}.{nameof(GetUsers)}: result = {test}");
                return Ok(new { status = Constants.Status.OK.ToString(), message = "Get users", result = test });
            }
            else
            {
                return Ok(new { status = Constants.Status.FAIL.ToString(), message = "No users"});
            }
        }

        [Route("GetAuditTrails")]
        [HttpGet]
        public async Task<IActionResult> GetAuditTrails()
        {
            _logger.LogDebug($"{nameof(UserController)}.{nameof(GetAuditTrails)}");

            //var test = _utils.GetAuditTrails(); // using Dapper
            //var test = _CadetAuditTrailDB.AuditTrails.Where(x => x.Action == "Delete").Take(2000).ToList(); // using 
            var test = _CadetAuditTrailDB.AuditTrails.FromSql($"EXECUTE dbo.prGetAuditTrails").ToList();
            if (test != null)
            {
                _logger.LogDebug($"{nameof(UserController)}.{nameof(GetAuditTrails)}: result = {test}");
                return Ok(new { status = Constants.Status.OK.ToString(), message = "Get users", result = test });
            }
            else
            {
                return Ok(new { status = Constants.Status.FAIL.ToString(), message = "No users" });
            }
        }
        //[HttpGet]
        //public async Task<IActionResult> GetUsers()
        //{
        //    var users = await _dbContent.Users.ToListAsync();

        //    return Ok(users);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddUser([FromBody]User userRequest)
        //{
        //    userRequest.UserId = Guid.NewGuid();

        //    await _dbContent.Users.AddAsync(userRequest);
        //    await _dbContent.SaveChangesAsync();

        //    return Ok(userRequest);
        //}
    }
}
