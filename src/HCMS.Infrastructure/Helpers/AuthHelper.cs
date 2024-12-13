using HCMS.Application.Common.Helpers;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Entities;
using HCMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Infrastructure.Helpers
{
    internal class AuthHelper : IAuthHelper
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IPasswordHasher _passwordHasher;
        internal HCMSDbContext _context;

        public AuthHelper(JwtSettings jwtSettings, IPasswordHasher passwordHasher,HCMSDbContext context)
        {
            _jwtSettings = jwtSettings;
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public async Task<User?> AuthenticateUser(AuthCreds authCreds)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == authCreds.Email);

            if (user == null)
            {
                return null;
            }

            if (_passwordHasher.VerifyPassword(user.PasswordHash, authCreds.Password))
            {
                return user;
            }

            return null;
        }
        public string GenerateJwt(string userId, string role)
        {
            var claims = new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                   issuer: _jwtSettings.Issuer,
                   audience: _jwtSettings.Audience,
                   claims: claims,
                   expires: DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpiryInMinutes),
                   signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<bool> UserWithEmailExists(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            return true;

        }
    }
}
