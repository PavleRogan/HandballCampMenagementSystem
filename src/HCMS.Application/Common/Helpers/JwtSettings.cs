using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Common.Helpers
{
    
        public class JwtSettings
        {
            public string SecretKey { get; set; } = null!;
            public string Issuer { get; set; } = null!;
            public string Audience { get; set; } = null!;
            public int TokenExpiryInMinutes { get; set; }
        }
    
}
