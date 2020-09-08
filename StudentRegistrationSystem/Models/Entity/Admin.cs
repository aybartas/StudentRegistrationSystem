using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models.Entity
{
    public class Admin
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }

    }
}