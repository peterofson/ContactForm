using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace BizSteam.Models
{
    public class ContactFormViewModel
    {
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Message { get; set; }

    }
    public class FormValidator : AbstractValidator<ContactFormViewModel>
    {
        public FormValidator()
        {
            RuleFor(x => x.Email).Must((model, mail) =>
            {
                var emailAddressAttribute = new EmailAddressAttribute();
                return emailAddressAttribute.IsValid(mail);
            }).WithMessage("Please enter a valid email");
        }
    }
}
