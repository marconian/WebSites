using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StalRondo.Utilities;

namespace StalRondo.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserID { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

    }
}