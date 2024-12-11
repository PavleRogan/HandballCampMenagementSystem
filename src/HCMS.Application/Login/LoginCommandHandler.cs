using HCMS.Application.Common.Helpers;
using HCMS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Login
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IAuthHelper _authHelper; 
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler( IAuthHelper authHelper, ILogger<LoginCommandHandler> logger)        {
            _authHelper = authHelper;
            _logger = logger;
            
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("User {@email} tries to log in", request.Email);

            var authCreds = new AuthCreds
            {
                Password = request.Password,
                Email = request.Email,
            };

            var user = await _authHelper.AuthenticateUser(authCreds);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            string userType = user.GetType().Name;
            var jwt = _authHelper.GenerateJwt(user.UserId.ToString(), userType);

            return jwt;
        }
    }
}
