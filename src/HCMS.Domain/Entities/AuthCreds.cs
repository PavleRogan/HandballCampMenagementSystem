using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class AuthCreds
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
