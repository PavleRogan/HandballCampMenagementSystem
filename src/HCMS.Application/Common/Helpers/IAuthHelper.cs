using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Common.Helpers
{
    public interface IAuthHelper
    {
        public Task<User?> AuthenticateUser(AuthCreds authCreds);

        public string GenerateJwt(string userId, string role);

        public Task<bool> UserWithEmailExists(string email);

    }
}
