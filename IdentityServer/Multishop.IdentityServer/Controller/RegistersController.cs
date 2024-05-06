using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Multishop.IdentityServer.Dtos;
using Multishop.IdentityServer.Models;
using System;
using System.Threading.Tasks;

namespace Multishop.IdentityServer.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto dto)
        {
            var value = new ApplicationUser()
            {
                UserName = dto.Username,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname
            };
            var result = await _userManager.CreateAsync(value, dto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi");
            }
            else
            {
                return Ok("Kullanıcı eklenirken hata oluştu");
            }

        }

    }
}
