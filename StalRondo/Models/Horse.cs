using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StalRondo.Models
{
    public class Horse
    {
        [Key, ForeignKey("Genealogy"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HorseID { get; set; }

        //[Key, ForeignKey("Genealogy")]
        //public int GenealogyID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual Genealogy Genealogy { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }

    }
}