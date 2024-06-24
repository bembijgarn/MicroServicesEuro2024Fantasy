using Euro2024Stat.AuthAPI.Interface;
using Euro2024Stat.AuthAPI.Models;
using Euro2024Stat.AuthAPI.Models.Dto;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Runtime.CompilerServices;

namespace Euro2024Stat.AuthAPI.Service
{
    public class AuthService : IAuth
    {
        private readonly UserContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwt _jwt;

        public AuthService(UserContext db, IJwt jwtTokenGenerator, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _jwt = jwtTokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> GiveRole(string email, string role)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    //create role if it does not exist
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole(role));
                    if (!roleResult.Succeeded)
                    {
                        return false; // Handle role creation failure
                    }
                }
                await _userManager.AddToRoleAsync(user, role);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginDto userdto)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName.ToLower() == userdto.Username.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, userdto.Password);

            if (!isValid  || user == null)
            {
                return new LoginResponseDto() { User = null, Token = "" };
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwt.GenerateToken(user, roles);

            var UserDto = user._MapUserToUserDto();

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = UserDto,
                Token = token
            };

            return loginResponseDto;
        }

        public async Task<string> Register(RegisterUserDto dtoUser)
        {
            User user = dtoUser._MapRegisterDtoToUser();

            try
            {
                var result = await _userManager.CreateAsync(user, dtoUser.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.Users.First(u => u.UserName == dtoUser.UserName);

                    UserDto userDto = userToReturn._MapUserToUserDto();

                    return "";

                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }
            catch (Exception ex)
            {

            }
            return "Error Encountered";
        }
    }
}
