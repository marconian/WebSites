using StalRondo.Utilities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StalRondo.Models
{
    public class Genealogy
    {
        [Key, ForeignKey("Horse"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HorseID { get; set; }

        [ForeignKey("Father")]
        public int? FatherID { get; set; }
        
        [ForeignKey("Mother")]
        public int? MotherID { get; set; }

        public virtual Horse Horse { get; set; }

        [Gender(Gender.Stallion)]
        public virtual Horse Father { get; set; }

        [Gender(Gender.Mare)]
        public virtual Horse Mother { get; set; }

    }
}