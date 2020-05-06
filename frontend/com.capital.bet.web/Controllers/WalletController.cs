using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using com.capital.bet.data;
using com.capital.bet.data.Models.Accounts;
using com.capital.bet.data.Models.Users;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace com.capital.bet.web.Controllers
{
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _dbManager;
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dbManager"></param>
        /// <param name="userManager"></param>
        /// <param name="memoryCache"></param>
        public WalletController(ILogger<AccountController> logger,
            IUnitOfWork dbManager,
            UserManager<ApplicationUser> userManager,
            IMemoryCache memoryCache)
        {
            _logger = logger;
            _dbManager = dbManager;
            _userManager = userManager;
            _memoryCache = memoryCache;
        }


        /// <summary>
        /// Get Current User 
        /// </summary>
        /// <returns><see cref="ApplicationUser"/></returns>
        private async Task<ApplicationUser> GetCurrentUser()
        {
            try
            {
                ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                return user;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get Current User Wallet Transactions
        /// </summary>
        /// <param name="start">Start Date</param>
        /// <param name="end">End Date</param>
        /// <returns></returns>
        [HttpGet]
        [Route("transactions")]
        [ProducesResponseType(typeof(List<WalletTransaction>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserWalletTransactions(DateTime? start, DateTime? end)
        {
            try
            {
                ApplicationUser usr = await GetCurrentUser();
                List<WalletTransaction> trs = new List<WalletTransaction>();
                trs = _dbManager.WalletTranactions.GetAll()
                    .Where(m => m.CreatedDate >= (start ?? DateTime.Now.Subtract(TimeSpan.FromDays(30))) &&
                                //m.CreatedDate <= (end ?? DateTime.Now) &&
                                m.AccountId == usr.AccountId).ToList();
                return Ok(trs);
            }catch(Exception es)
            {
                _logger.LogError(es, "");
                return StatusCode(500, "");
            }
        }

        /// <summary>
        /// Get The Current User Balance
        /// </summary>
        /// <returns><see cref="WalletBalanceResponse"/></returns>
        [HttpGet]
        [Route("balance")]
        [ProducesResponseType(typeof(WalletBalanceResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCurrentWalletBalance()
        {
            try
            {
                ApplicationUser user = await GetCurrentUser();
                UserAccount account = _dbManager.UserAccounts.Get(user.AccountId);
                return Ok(new WalletBalanceResponse()
                {
                    Balance = account.Balance
                });
            }catch(Exception es)
            {
                _logger.LogError(es, "");
                return StatusCode(500, "");
            }
        }

        /// <summary>
        /// Get the Users last deposit
        /// </summary>
        [HttpGet]
        [Route("last/deposit")]
        [ProducesResponseType(typeof(WalletTransaction), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserLastDeposit()
        {
            try
            {
                ApplicationUser user = await GetCurrentUser();
                var trs = _dbManager.WalletTranactions.GetAll().Where(m => m.AccountId == user.AccountId).OrderBy(m => m.CreatedDate).FirstOrDefault();
                return Ok(trs);
            }
            catch(Exception es)
            {
                _logger.LogError(es, "");
                return StatusCode(500, "");
            }
        }

        /// <summary>
        /// Get the Users total deposit
        /// </summary>
        [HttpGet]
        [Route("total/deposit")]
        [ProducesResponseType(typeof(WalletBalanceResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserTotalDeposit()
        {
            try
            {
                ApplicationUser user = await GetCurrentUser();
                decimal balance = 0;
                var trs = _dbManager.WalletTranactions.GetAll().Where(m => m.AccountId == user.AccountId).OrderBy(m => m.CreatedDate).ToList();
                foreach(var t in trs)
                {
                    balance += t.Amount;
                }
                return Ok(new WalletBalanceResponse()
                {
                    Balance=balance
                });
            }
            catch (Exception es)
            {
                _logger.LogError(es, "");
                return StatusCode(500, "");
            }
        }



    }


    /// <summary>
    /// Wallet Balance Response
    /// </summary>
    public class WalletBalanceResponse
    {
        /// <summary>
        /// Current Balance
        /// </summary>
        public decimal Balance { get; set; }
    }
}