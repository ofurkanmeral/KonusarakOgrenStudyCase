﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Web.Models
{
    public class UserViewModel
    {
        [Required]
        public string username { get; set; }
        [Required, DataType(DataType.Password)]
        public string password { get; set; }
    }
}
