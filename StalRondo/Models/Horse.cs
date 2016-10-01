using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StalRondo.Utilities;

namespace StalRondo.Models
{
    public class Horse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HorseID { get; set; }
        
        public Guid? ProfilePictureID { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }

    }
}