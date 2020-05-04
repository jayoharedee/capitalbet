using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using com.capital.bet.data;
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
    public class AccountController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUnitOfWork _dbManager;
        private readonly IMemoryCache _memoryCache;

        public AccountController(ILogger<AccountController> logger,
            IUnitOfWork dbManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IMemoryCache memoryCache)
        {
            _logger = logger;
            _dbManager = dbManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _memoryCache = memoryCache;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUserAccount()
        {
            try
            {
                return NotFound();
            }catch(Exception es)
            {
                _logger.LogError(es, $"");
                return StatusCode(500, $"");
            }
        }



    }
}