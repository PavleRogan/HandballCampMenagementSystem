using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Register
{
    public class RegisterCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Please provide valid email address")]
        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        [Phone(ErrorMessage = "Please provide valid phone number")]
        public string PhoneNumber { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        [StringLength(10)]
        public string Gender { get; set; } = null!;

        [StringLength(50)]
        public string HomeTown { get; set; } = null!;

        [StringLength(20)]
        public string? Position { get; set; }

        [StringLength(50)]
        public string? TeamName { get; set; }

        [StringLength(5)]
        public string? EquipmentSize { get; set; }

        [EmailAddress(ErrorMessage = "Enter valid email adress")]
        public string? ParentEmail { get; set; }

    }
}
