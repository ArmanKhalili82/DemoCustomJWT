using JWTAuthenticationServer.Data;
using Microsoft.AspNetCore.Identity;
using SharedClassLibrary.Contracts;
using SharedClassLibrary.DTOs;
using static SharedClassLibrary.DTOs.ServiceResponses;

namespace JWTAuthenticationServer.Repositories
{
    public class AccountRepository(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration config)
        : IUserAccount
    {
        public async Task<ServiceResponses.GeneralResponse> Createaccount(UserDto userDto)
        {
            if (userDto is null) return new GeneralResponse(false, "Model Is Empty");
            var newUser = new ApplicationUser()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = userDto.Password,
                UserName = userDto.Email
            };
            
            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user is null) return new GeneralResponse(false, "User registered already");

            var createUser = await userManager.CreateAsync(newUser!, userDto.Password);
            if (!createUser.Succeeded) return new GeneralResponse(false, "Error Occured please try again");

            var checkAdmin = await roleManager.FindByNameAsync("Admin");
            if (checkAdmin is null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await userManager.AddToRoleAsync(newUser, "Admin");
                return new GeneralResponse(true, "Account Created");
            }
            else
            {
                var checkUser = await roleManager.FindByNameAsync("User");
                if (checkUser is null)
                    await roleManager.CreateAsync(new IdentityRole() { Name = "User" });

                await userManager.AddToRoleAsync(newUser, "User");
                return new GeneralResponse(true, "Account Created");
            }
        }

        public Task<ServiceResponses.LoginResponse> LoginAccount(LoginDTO loginDto)
        {
            throw new NotImplementedException();
        }
    }
}
