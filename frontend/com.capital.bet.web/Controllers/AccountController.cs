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
    /// <summary>
    /// Account Controller
    /// </summary>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dbManager"></param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="memoryCache"></param>
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


        /// <summary>
        /// Handle Exceptions
        /// </summary>
        /// <param name="es">Exception Object</param>
        /// <param name="logmessage">Logger Message</param>
        /// <param name="outmessage">Output Client Message</param>
        /// <returns>IActionResult with status code 500</returns>
        private IActionResult HandleException(Exception es, string logmessage, string outmessage)
        {

            _logger.LogError(es, logmessage);
            return StatusCode(StatusCodes.Status500InternalServerError, outmessage);
        }



        /// <summary>
        /// Get An Account By Id
        /// </summary>
        /// <param name="userId">User Id</param>
        [HttpGet]
        [Route("users/{userId}")]
        [ProducesResponseType(typeof(ApplicationUser), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(userId);
                user.PasswordHash = "";
                user.SecurityStamp = "";
                user.ConcurrencyStamp = "";
                return Ok(user);
            }
            catch (Exception es)
            {
                return HandleException(es, $"Failed to retrieve User account By Id {userId}", "Failed to retrieve User account By Id");
            }
        }

        /// <summary>
        /// Get the current authorized user
        /// </summary>
        [HttpGet]
        [Route("users/current")]
        [ProducesResponseType(typeof(ApplicationUser), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PasswordHash = string.Empty;
                user.SecurityStamp = string.Empty;
                user.ConcurrencyStamp = string.Empty;
                return Ok(user);
            }
            catch (Exception es)
            {
                _logger.LogError(es, "Failed to get current user from the current context");
                return StatusCode(500, "Failed to get the current user from the current context");
            }
        }

        /// <summary>
        /// Get a list of user roles
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [Route("user/roles")]
        [ProducesResponseType(typeof(List<ApplicationRole>), StatusCodes.Status200OK)]
        public IActionResult GetUserRoles()
        {
            try
            {
                return Ok(_roleManager.Roles.ToList());
            }
            catch (Exception es)
            {
                return HandleException(es, "Failed to retrieve user roles ...", "Failed to retrieve user roles ...");
            }
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="request"><see cref="CreateUserRequest"/></param>
        /// <returns><see cref="ApplicationUser"/></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("users/create")]
        [ProducesResponseType(typeof(ApplicationUser), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterNewUser([FromBody]CreateUserRequest request)
        {
            try
            {
                Guid accId = Guid.NewGuid();
                // Create OAuth Account
                ApplicationUser user = request.User;
                ApplicationUser auser = new ApplicationUser()
                {
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    IsEnabled = true,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    ProfileImage = user.ProfileImage,
                    MobileNumber = user.MobileNumber,
                    AccountId = accId
                };
                // Create User Account
                UserAccount account = new UserAccount()
                {
                    AcountId = accId,
                    UserId = auser.Id,
                    Balance = request.DepositAmount,
                    TypeId = request.AccountType
                };

                // try to create user
                IdentityResult res = await _userManager.CreateAsync(auser, request.Password);
                if (res.Succeeded)
                {
                    IdentityResult res2 = await _userManager.AddToRoleAsync(auser, "tradder");
                    if (res2.Succeeded)
                    {
                        // Save User Account
                        _dbManager.UserAccounts.Add(account);
                        _dbManager.SaveChanges();
                        // return user object
                        auser.PasswordHash = "";
                        return Ok(auser);
                    }
                    else
                    {
                        _logger.LogInformation("Failed to add requested user to default roles ...");
                        return StatusCode(500, "Failed to add requested user to default roles ...");
                    }
                }
                else
                {
                    _logger.LogInformation("Failed to add requested user to system...");
                    return StatusCode(500, "Failed to add requested user to system...");
                }

            }
            catch (Exception es)
            {
                return HandleException(es, $"Failed to register the requested user on the system {request}", "Failed to register the requested user on the system.");
            }
        }

        /// <summary>
        /// Update User Account
        /// </summary>
        /// <param name="usr"><see cref="ApplicationUser"/></param>
        /// <returns>Updated <see cref="ApplicationUser"/></returns>
        [HttpPost]
        [Route("users/update")]
        [ProducesResponseType(typeof(ApplicationUser), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserAccount([FromBody]ApplicationUser usr)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(usr.Id);
                if (user != null)
                {
                    user.FirstName = usr.FirstName;
                    user.LastName = usr.LastName;
                    user.Email = usr.Email;
                    user.UserName = usr.UserName;
                    user.PhoneNumber = usr.PhoneNumber;
                    user.ProfileImage = usr.ProfileImage;
                    user.IsEnabled = usr.IsEnabled;
                    user.MobileNumber = usr.MobileNumber;
                    await _userManager.UpdateAsync(user);
                }
                user.PasswordHash = "";
                user.ConcurrencyStamp = "";
                user.SecurityStamp = "";
                return Ok(user);
            }
            catch (Exception es)
            {
                _logger.LogError(es, "Failed to update the requested user information ...");
                return StatusCode(500, "Failed to update the requested user information ...");
            }
        }

        /// <summary>
        /// Check if username is valid
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>result is true on valid otherwise false</returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("checkusername")]
        public async Task<IActionResult> UsernameValid(string username)
        {
            try
            {
                ApplicationUser usr = await _userManager.FindByNameAsync(username);
                if (usr == null)
                {
                    if (username.Length < 6)
                        return Ok(new { result = false });
                    return Ok(new { result = true });
                }

                if (username == usr.UserName)
                    return Ok(new { result = true });

                return Ok(new { result = false });
            }
            catch (Exception es)
            {
                _logger.LogError(es, $"Failed to check the username for {username}");
                return Ok(new { result = false });
            }
        }

        /// <summary>
        /// Get a list of account types
        /// </summary>
        /// <returns>list of <see cref="AccountType"/></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("types")]
        [ProducesResponseType(typeof(List<AccountType>), StatusCodes.Status200OK)]
        public IActionResult GetAccountTypes()
        {
            try
            {
                return Ok(_dbManager.AccountTypes.GetAll().OrderBy(m => m.MinimumDeposit).ToList());
            }
            catch (Exception es)
            {
                _logger.LogError(es, "Failed to get the account types ...");
                return StatusCode(500, "Failed to get the account types ...");
            }
        }


    }

    /// <summary>
    /// Update Password Request Object
    /// </summary>
    public class UpdatePasswordRequest
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Old Password
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// New Password
        /// </summary>
        public string NewPassword { get; set; }

    }

    /// <summary>
    /// Create user request object
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// Application User <see cref="ApplicationUser"/>
        /// </summary>
        public ApplicationUser User { get; set; }
        /// <summary>
        /// Account Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// deposit Amount
        /// </summary>
        public decimal DepositAmount { get; set; }
        /// <summary>
        /// Account Type Id
        /// </summary>
        public Guid AccountType { get; set; }
    }
}