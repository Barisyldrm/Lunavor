using System;
using System.Threading.Tasks;
using Lunavor.Core.Services;
using Lunavor.Core;
using Lunavor.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Lunavor.Business.Interfaces;
using BCrypt.Net;

namespace Lunavor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserService userService, ITokenService tokenService, ILogger<AuthController> logger)
        {
            _userService = userService;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            try
            {
                _logger.LogInformation($"Giriş denemesi - Kullanıcı adı: {model.Email}");

                var users = await _userService.GetAllAsync();
                var user = users.FirstOrDefault(u => u.Email == model.Email);

                if (user == null)
                {
                    return Unauthorized(new { message = "Kullanıcı adı veya şifre hatalı." });
                }

                if (!BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                {
                    return Unauthorized(new { message = "Kullanıcı adı veya şifre hatalı." });
                }

                var token = _tokenService.GenerateToken(user);
                _logger.LogInformation($"Kullanıcı başarıyla giriş yaptı - Username: {user.Username}");

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Giriş sırasında hata oluştu");
                return StatusCode(500, new { message = "Bir hata oluştu. Lütfen daha sonra tekrar deneyin." });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            try
            {
                _logger.LogInformation($"Kayıt denemesi - Kullanıcı adı: {model.Username}, Email: {model.Email}");

                var users = await _userService.GetAllAsync();
                if (users.Any(u => u.Username == model.Username || u.Email == model.Email))
                {
                    return BadRequest(new { message = "Kullanıcı adı veya e-posta zaten kullanılıyor." });
                }

                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
                var user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    PasswordHash = hashedPassword,
                    Role = "Admin"
                };

                await _userService.AddAsync(user);
                _logger.LogInformation($"Kullanıcı başarıyla oluşturuldu - Username: {user.Username}");

                return Ok(new { message = "Kullanıcı başarıyla oluşturuldu." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kullanıcı kaydı sırasında hata oluştu");
                return StatusCode(500, new { message = "Bir hata oluştu. Lütfen daha sonra tekrar deneyin." });
            }
        }
    }

    public class RegisterRequest
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Kullanıcı adı 3-50 karakter arasında olmalıdır.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public required string Password { get; set; }
    }

    public class LoginRequest
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        public required string Password { get; set; }
    }
} 