using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;

namespace StalRondo.Models
{
    public class Picture
    {
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PictureID { get; set; }

        [Column(Order = 1), Key, ForeignKey("Horse")]
        public int HorseID { get; set; }

        public string Description { get; set; }

        [Required]
        public byte[] Data { get; set; }

        public virtual Horse Horse { get; set; }
    
    }
}