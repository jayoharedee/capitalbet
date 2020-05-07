using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using com.capital.bet.data;
using com.capital.bet.data.Models.Stocks;
using com.capital.bet.data.Models.Users;
using com.capital.bet.lib.Stocks;
using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace com.capital.bet.web.Controllers
{
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _dbManager;

        public StocksController(ILogger<StocksController> logger,
            UserManager<ApplicationUser> userManager,
            IUnitOfWork dbManager)
        {
            _dbManager = dbManager;
            _logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// Add Stocks to History Data
        /// </summary>
        /// <param name="request"><see cref="StockPriceUpdate"/></param>
        /// <returns>A list of <see cref="StockTick"/></returns>
        [HttpPost]
        [Route("stocks/add")]
        [ProducesResponseType(typeof(List<StockTick>), StatusCodes.Status200OK)]
        public IActionResult SaveStockPrices([FromBody]StockPriceUpdate request)
        {
            try
            {
                List<StockTick> ticks = new List<StockTick>();
                foreach(var stk in request.Stocks)
                {
                    StockTick tick = new StockTick()
                    {
                        StockId = stk.Currency.Replace("/", "_"),
                        TimeStamp = UnixTimeStampToDateTime(stk.Timestamp),
                        Rate = stk.Rate,
                        Ask = stk.Ask,
                        Bid = stk.Bid,
                        Close = stk.Close,
                        High=  stk.High,
                        Low = stk.Low,
                        Open = stk.Open
                    };
                    ticks.Add(tick);
                }
                // Save Data
                _dbManager.StockTicks.AddRange(ticks);
                _dbManager.SaveChanges();
                return Ok(ticks);
            }catch(Exception es)
            {
                _logger.LogError(es, "Failed to add the requested stock records to the system ...");
                return StatusCode(500, "Failed to add the requested stock records to the system ...");
            }
        }

        /// <summary>
        /// Get A list of the Supported Stocks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("types")]
        [ProducesResponseType(typeof(List<Stock>), StatusCodes.Status200OK)]
        public IActionResult GetSupportedStocks()
        {
            try
            {
                List<Stock> stocks = _dbManager.Stocks.GetAll().Where(m=>m.Enabled).OrderBy(m => m.Name).ToList();
                return Ok(stocks);
            }catch(Exception es)
            {
                _logger.LogError(es, "Failed to get the available stock types");
                return StatusCode(500, "Failed to get the available stock types");
            }
        }

        /// <summary>
        /// Get Simulated market Data
        /// </summary>
        [HttpGet]
        [Route("simulated")]
        [ProducesResponseType(typeof(List<StockRate>), StatusCodes.Status200OK)]
        public IActionResult GetSimulatedData()
        {
            try
            {
                List<StockRate> rates = new List<StockRate>();
                var result  = _dbManager.StockTicks.GetAll().OrderBy(m => m.TimeStamp);
                foreach(var itm in result)
                {
                    StockRate r = new StockRate()
                    {
                        Ask = itm.Ask,
                        Bid = itm.Bid,
                        Close = itm.Close,
                        Currency = itm.StockId,
                        High = itm.High,
                        Low = itm.Low,
                        Open = itm.Low,
                        Rate = itm.Rate,
                        Timestamp = itm.TimeStamp.ToEpochTime()
                    };
                    rates.Add(r);
                }
                return Ok(rates);
            }catch(Exception es)
            {
                _logger.LogError(es, "Failed to get simulated data");
                return StatusCode(500, "Failed to get simulated data");
            }
        }

        /// <summary>
        /// Get Stock By Id
        /// </summary>
        /// <param name="id">Stock Id</param>
        [HttpGet]
        [Route("stock/{id}")]
        [ProducesResponseType(typeof(Stock), StatusCodes.Status200OK)]
        public IActionResult GetStockById(string id)
        {
            try
            {
                return Ok(_dbManager.Stocks.Get(id));
            }catch(Exception es)
            {
                _logger.LogError(es, "");
                return StatusCode(500, "");
            }
        }


        private DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }


    public class StockPriceUpdate
    {
        public List<StockRate> Stocks { get; set; }
    }
}