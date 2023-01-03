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
using System.Transactions;
using Azure;

namespace Angular_link_to_DB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        //private readonly DbContent _dbContent;
        private readonly ILogger<TransactionController> _logger;
        private readonly IConfiguration _configuration;
        private readonly Utils _utils;
        private readonly CadetDbContext _CadetDB;
        private readonly CadetAuditTrailDbContext _CadetAuditTrailDB;
        private readonly TestingContext _testingContext;

        public TransactionController(ILogger<TransactionController> logger, IConfiguration configuration,Utils utils, CadetDbContext cadetDb, CadetAuditTrailDbContext cadetAuditTrailDB, TestingContext testingContext)
        {
            _logger = logger;
            _configuration = configuration;
            _utils = utils;
            _CadetDB = cadetDb;
            _CadetAuditTrailDB = cadetAuditTrailDB;
            _testingContext = testingContext;
            //_dbContent = dbContent;
        }

        [Route("GetTransactions")]
        [HttpGet]
        public async Task<IActionResult> GetTransaction()
        {
            _logger.LogDebug($"{nameof(TransactionController)}.{nameof(GetTransaction)}");

            //var test = _utils.GetAuditTrails(); // using Dapper
            //var test = _CadetAuditTrailDB.AuditTrails.Where(x => x.Action == "Delete").Take(2000).ToList(); // using Entity Framework Core
            //var invoice = _CadetAuditTrailDB.AuditTrails.FromSql($"EXECUTE dbo.prGetAuditTrails").ToList(); // using Entity Framework Core + Stored Procedure
            var invoice = _testingContext.TmpTransactions.FromSql($"EXECUTE dbo.prGetTransaction {"INVOICE"}").ToList();
            var receipt = _testingContext.TmpTransactions.FromSql($"EXECUTE dbo.prGetTransaction {"RECEIPT"}").ToList();

            List<ResultTransaction> transactions = new List<ResultTransaction>();

            for(int i = 0; i < invoice.ToList().Count; i++)
            {
                if(i == 0)
                {
                    string date = FormatDate(invoice[i].Dateissued.ToString().Split(' ')[0]);
                    // check the first element
                    ResultTransaction resultTransaction = new ResultTransaction() { 
                        No = i + 1, 
                        RefNo = invoice[i].RefNo, 
                        Dateissued = date, 
                        NetTotal = invoice[i].Amt, 
                        BalanceDue = invoice[i].Amt 
                    };

                    // added to list
                    transactions.Add(resultTransaction);

                    // check the current record got invoice or not
                    var tmp = receipt.Where(x => x.Invoice == invoice[i].RefNo).ToList();

                    if (tmp.Count > 0)
                    {
                        for (int j = 0; j < tmp.Count; j++)
                        {
                            date = FormatDate(tmp[j].Dateissued.ToString().Split(' ')[0]);
                            ResultTransaction resultTransactionReceipt = new ResultTransaction()
                            {
                                No = transactions[0].No + j + 1,
                                RefNo = "RECEIPTREFNO",
                                Dateissued = date,
                                NetTotal = -tmp[j].Amt,
                                BalanceDue = -tmp[j].Amt + invoice[0].Amt
                            };

                            transactions.Add(resultTransactionReceipt);
                        }
                    }
                }
                else if(i > 0)
                {
                    string date = FormatDate(invoice[i].Dateissued.ToString().Split(' ')[0]);
                    ResultTransaction resultTransaction = new ResultTransaction()
                    {
                        No = transactions[transactions.Count - 1].No + 1,
                        RefNo = invoice[i].RefNo,
                        Dateissued = date,
                        NetTotal = invoice[i].Amt,
                        BalanceDue = invoice[i].Amt + transactions[transactions.Count - 1].BalanceDue
                    };

                    transactions.Add(resultTransaction);

                    var tmp = receipt.Where(x => x.Invoice == invoice[i].RefNo).ToList();

                    if (tmp.Count > 0)
                    {
                        for (int j = 0; j < tmp.Count; j++)
                        {
                            date = FormatDate(tmp[j].Dateissued.ToString().Split(' ')[0]);
                            ResultTransaction resultTransactionReceipt = new ResultTransaction()
                            {
                                No = transactions[transactions.Count - 1].No + j + 1,
                                RefNo = "RECEIPTREFNO",
                                Dateissued = date,
                                NetTotal = -tmp[j].Amt,
                                BalanceDue = -tmp[j].Amt + transactions[transactions.Count - 1].BalanceDue
                            };

                            transactions.Add(resultTransactionReceipt);
                        }
                    }
                    
                }
            }

            if (transactions != null)
            {
                _logger.LogDebug($"{nameof(TransactionController)}.{nameof(GetTransaction)}: result = {transactions}");
                return Ok(new { status = Constants.Status.OK.ToString(), message = "Get Transactions", result = transactions });
            }
            else
            {
                return Ok(new { status = Constants.Status.FAIL.ToString(), message = "No Transaction" });
            }
        }

        
        [Route("RegisterEmployee")]
        [HttpPost]
        public async Task<IActionResult> RegisterEmployee(string name,string loginId)
        {
            var response = _testingContext.TmpTransactions.FromSql($"EXECUTE prRegisterEmployee {name},{loginId}");

            if(response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("The action failed");
            }
        }


        [Route("DeleteEmployee")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response = _testingContext.TmpTransactions.FromSql($"EXECUTE prDeleteEmployee {id}");

            if(response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("The action failed");
            }
        }

        [Route("EnquireEmployee")]
        [HttpGet]
        public async Task<IActionResult> EnquireEmployee(int id)
        {
            var response = _testingContext.TmpTransactions.FromSql($"EXECUTE prEnquireEmployee {id}");

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("The action failed");
            }
        }

        
        public static string FormatDate(string date)
        {
            var split = date.Split('/');
            var result = split[1] + '/' + split[0] + '/' + split[2];
            return result;
        }
    }
}
