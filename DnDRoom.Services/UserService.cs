using DnDRoom.Contracts;
using DnDRoom.Data;
using DnDRoom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DnDRoom.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(
            IUserRepo userRepo,
            IJwtService jwtService,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userRepo = userRepo;
            _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Create(RegisterModel registerModel)
        {
            
            User newUser = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName,
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, registerModel.Password);
            if(!result.Succeeded)
            {
                return new BadRequestObjectResult(result.Errors);
            }
            registerModel.Password = null;
            return new CreatedResult("", registerModel);
        }

        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                return new BadRequestObjectResult("Bad credentials");
            }

            var passwordValidation = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!passwordValidation)
            {
                return new BadRequestObjectResult("Bad credentials");
            }

            var newToken = _jwtService.CreateToken(user);
            return new OkObjectResult(newToken);
        }

        public async Task<User> GetById(string Id)
        {
            return await _userManager.FindByIdAsync(Id);
        }
    }
}