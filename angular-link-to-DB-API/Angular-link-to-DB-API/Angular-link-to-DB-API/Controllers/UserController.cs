using Angular_link_to_DB_API.Common;
using Angular_link_to_DB_API.Data;
using Angular_link_to_DB_API.Db;
using Angular_link_to_DB_API.Helpers;
using Angular_link_to_DB_API.Models;
using Angular_link_to_DB_API.Request.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Angular_link_to_DB_API.Common.Constants;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace Angular_link_to_DB_API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        //private readonly DbContent _dbContent;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        private readonly Utils _utils;
        private readonly CadetDbContext _CadetDB;
        private readonly CadetAuditTrailDbContext _CadetAuditTrailDB;
        private readonly TestingContext _testingContext;

        public UserController(ILogger<UserController> logger, IConfiguration configuration,Utils utils, CadetDbContext cadetDb, CadetAuditTrailDbContext cadetAuditTrailDB, TestingContext testingContext)
        {
            _logger = logger;
            _configuration = configuration;
            _utils = utils;
            _CadetDB = cadetDb;
            _CadetAuditTrailDB = cadetAuditTrailDB;
            _testingContext = testingContext;
            //_dbContent = dbContent;
        }

        [Authorize]
        [Route("GetUsers")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            _logger.LogDebug($"{nameof(UserController)}.{nameof(GetUsers)}");

            //var test = _utils.GetUsers();
            //var test = _CadetDB.Users.ToList();
            var test = _CadetDB.Users.FromSql($"EXECUTE dbo.prGetUsers").ToList();
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

        [Authorize]
        [Route("GetUserById")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            _logger.LogDebug($"{nameof(UserController)}.{nameof(GetUserById)}");

            //var test = _utils.GetUsers();
            var test = _CadetDB.Users.Where(x => x.Id == id).ToList();
            //var test = _CadetDB.Users.FromSql($"EXECUTE dbo.prGetUsers").ToList();
            if (test != null)
            {
                _logger.LogDebug($"{nameof(UserController)}.{nameof(GetUserById)}: result = {test}");
                return Ok(new { status = Constants.Status.OK.ToString(), message = "Get user by id", result = test });
            }
            else
            {
                return Ok(new { status = Constants.Status.FAIL.ToString(), message = "No users" });
            }
        }

        [Authorize]
        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            _logger.LogDebug($"{nameof(UserController)}.{nameof(AddUser)}");
            string adminId = Constants.currentAdminId;
            string loginId = request.userName;
            DateTime startDay = DateTime.Now;
            DateTime endDay = startDay.AddDays(100);
            string remarks = "";
            string groupId = "98567063-6A0B-4A22-98DC-511AF746F5C6"; // Executive group
            string status = "257B502A-EEA5-48D5-86B3-EDA5F630C9B8"; // Active
            string department = "0C6F9713-43C3-4A6D-A09A-ED9A1D72FD97"; // IAD
            string emailAddress = request.emailAddress;
            string userName = request.userName;

            //var test = _utils.GetUsers();
            //var test = _CadetDB.Users.Where(x => x.Id == id).ToList();
            var test = _CadetDB.Users.
                FromSql($@"EXECUTE dbo.prAddUserInGroup {loginId},{userName},
                        {Guid.Parse(department)}, {emailAddress},{Guid.Parse(status)},{startDay},
                        {endDay},{remarks},{Guid.Parse(groupId)},{Guid.Parse(adminId)}")
                .ToList();
            if (test != null)
            {
                _logger.LogDebug($"{nameof(UserController)}.{nameof(AddUser)}: result = {test}");
                return Ok(new { status = Constants.Status.OK.ToString(), message = "Add user", result = test });
            }
            else
            {
                return Ok(new { status = Constants.Status.FAIL.ToString(), message = "No users" });
            }
        }

        [Authorize]
        [Route("EditUser")]
        [HttpPut]
        public async Task<IActionResult> EditUser([FromBody] EditUserRequest request)
        {
            _logger.LogDebug($"{nameof(UserController)}.{nameof(EditUser)}");
            string adminId = Constants.currentAdminId;
            DateTime startDay = DateTime.Now;
            DateTime endDay = startDay.AddDays(100);
            string remarks = "";
            string groupId = "98567063-6A0B-4A22-98DC-511AF746F5C6"; // Executive group
            string status = "257B502A-EEA5-48D5-86B3-EDA5F630C9B8"; // Active
            string department = "0C6F9713-43C3-4A6D-A09A-ED9A1D72FD97"; // IAD
            string userId = request.id;
            string emailAddress = request.emailAddress;
            string userName = request.userName;

            //var test = _utils.GetUsers();
            //var test = _CadetDB.Users.Where(x => x.Id == id).ToList();
            var test = _CadetDB.Users.
                FromSql($@"EXECUTE dbo.prEditUser {Guid.Parse(userId)},{userName},
                        {Guid.Parse(department)}, {emailAddress},{Guid.Parse(status)},{startDay},
                        {endDay},{remarks},{Guid.Parse(groupId)},{Guid.Parse(adminId)}")
                .ToList();
            if (test != null)
            {
                _logger.LogDebug($"{nameof(UserController)}.{nameof(EditUser)}: result = {test}");
                return Ok(new { status = Constants.Status.OK.ToString(), message = "Edit user", result = test });
            }
            else
            {
                return Ok(new { status = Constants.Status.FAIL.ToString(), message = "No users" });
            }
        }

        [Authorize]
        [Route("DeleteUser")]
        [HttpPut]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request)
        {

            _logger.LogDebug($"{nameof(UserController)}.{nameof(DeleteUser)}");
            string adminId = Constants.currentAdminId;

            var test = _CadetDB.Users.
            FromSql($@"EXECUTE dbo.prDeleteUser {Guid.Parse(request.id)},{Guid.Parse(adminId)}")
                .ToList();

            if (test != null)
            {
                _logger.LogDebug($"{nameof(UserController)}.{nameof(DeleteUser)}: result = {test}");
                return Ok(new { status = Constants.Status.OK.ToString(), message = "Delete user", result = test });
            }
            else
            {
                return Ok(new { status = Constants.Status.FAIL.ToString(), message = "No users" });
            }
        }

        //[Route("GetAuditTrails")]
        //[HttpGet]
        //public async Task<IActionResult> GetAuditTrails()
        //{
        //    _logger.LogDebug($"{nameof(UserController)}.{nameof(GetAuditTrails)}");

        //    //var test = _utils.GetAuditTrails(); // using Dapper
        //    //var test = _CadetAuditTrailDB.AuditTrails.Where(x => x.Action == "Delete").Take(2000).ToList(); // using Entity Framework Core
        //    var test = _CadetAuditTrailDB.AuditTrails.FromSql($"EXECUTE dbo.prGetAuditTrails").ToList(); // using Entity Framework Core + Stored Procedure
        //    if (test != null)
        //    {
        //        _logger.LogDebug($"{nameof(UserController)}.{nameof(GetAuditTrails)}: result = {test}");
        //        return Ok(new { status = Constants.Status.OK.ToString(), message = "Get audit trails", result = test });
        //    }
        //    else
        //    {
        //        return Ok(new { status = Constants.Status.FAIL.ToString(), message = "No users" });
        //    }
        //}

        [Authorize]
        [Route("GetTransactions")]
        [HttpGet]
        public async Task<IActionResult> GetTransaction()
        {
            _logger.LogDebug($"{nameof(UserController)}.{nameof(GetTransaction)}");

            //var test = _utils.GetAuditTrails(); // using Dapper
            //var test = _CadetAuditTrailDB.AuditTrails.Where(x => x.Action == "Delete").Take(2000).ToList(); // using Entity Framework Core
            //var invoice = _CadetAuditTrailDB.AuditTrails.FromSql($"EXECUTE dbo.prGetAuditTrails").ToList(); // using Entity Framework Core + Stored Procedure
            var invoice = _testingContext.TmpTransactions.FromSql($"EXECUTE dbo.prGetTransaction {"INVOICE"}").ToList();
            var receipt = _testingContext.TmpTransactions.FromSql($"EXECUTE dbo.prGetTransaction {"RECEIPT"}").ToList();

            if (invoice != null)
            {
                _logger.LogDebug($"{nameof(UserController)}.{nameof(GetTransaction)}: result = {invoice}");
                return Ok(new { status = Constants.Status.OK.ToString(), message = "Get Transactions", result = invoice });
            }
            else
            {
                return Ok(new { status = Constants.Status.FAIL.ToString(), message = "No transaction" });
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
