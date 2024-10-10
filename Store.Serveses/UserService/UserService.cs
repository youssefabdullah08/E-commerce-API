using Microsoft.AspNetCore.Identity;
using Store.Data.Entites;
using Store.Serveses.TokenServece;
using Store.Serveses.UserService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenServece token;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenServece token)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.token = token;
        }
        public async Task<UserDTO> login(LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
                return null;

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!result.Succeeded)
                throw new Exception("login failed");

            return new UserDTO
            {
                Id = Guid.Parse(user.Id),
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = token.GenritToken(user)
            };
        }

        public async Task<UserDTO> Register(RegsterDTO regsterDTO)
        {
            var user = await userManager.FindByEmailAsync(regsterDTO.Email);
            if (user != null)
                return null;

            var appuser = new AppUser
            {
                DisplayName = regsterDTO.DisplayName,
                Email = regsterDTO.Email,
                UserName = regsterDTO.DisplayName,
            };
            var result = await userManager.CreateAsync(appuser, regsterDTO.Password);
            if (!result.Succeeded)
                throw new Exception(result.Errors.Select(x => x.Description).FirstOrDefault());

            return new UserDTO
            {
                DisplayName = appuser.DisplayName,
                Email = appuser.Email,
                Id = Guid.Parse(appuser.Id),
                Token = token.GenritToken(appuser)
            };

        }
    }
}
