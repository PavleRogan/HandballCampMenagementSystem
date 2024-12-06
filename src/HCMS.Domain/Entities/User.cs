using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public abstract class User
    {
        public Guid UserId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        [EmailAddress(ErrorMessage ="Please provide valid email address")]
        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        [Phone(ErrorMessage = "Please provide valid phone number")]
        public string PhoneNumber { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        [StringLength(10)]
        public string Gender { get; set; } = null!;

        [StringLength(50)]
        public string HomeTown { get; set; } = null!;


    }
}
