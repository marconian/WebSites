using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StalRondo.Models
{
    public class Genealogy
    {
        [Key, ForeignKey("Horse"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HorseID { get; set; }

        [ForeignKey("Father")]
        public int? FatherID { get; set; }
        
        [ForeignKey("Mother")]
        public int? MotherID { get; set; }

        public virtual Horse Horse { get; set; }
        public virtual Horse Father { get; set; }
        public virtual Horse Mother { get; set; }

    }
}