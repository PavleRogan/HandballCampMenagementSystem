using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string message) : base(message)
        {


        }
    }
}
