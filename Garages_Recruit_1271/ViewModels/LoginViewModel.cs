using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Garages_Recruit_1271.Utilities;
using Microsoft.AspNetCore.Authentication;

namespace Garages_Recruit_1271.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
       // [ValidationEmailDomain(allowedDomain:"pragimtech.com", ErrorMessage = "Email domain must be pragimtech.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Remember me")]
        public bool rememberMe { get; set; }
        public List<AuthenticationScheme> ExternalLogins { get; internal set; }
        public string ReturnUrl { get; internal set; }
    }
}
