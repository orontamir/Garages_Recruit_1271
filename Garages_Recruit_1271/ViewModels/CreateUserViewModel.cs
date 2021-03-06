﻿using Garages_Recruit_1271.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garages_Recruit_1271.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name can not be exceed 50 charecters")]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid Email Format")]
        public string Mail { get; set; }

        public Status? Status { get; set; }

        public IFormFile Photo { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
