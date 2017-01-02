using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StalRondo.Utilities;

namespace StalRondo.Models
{
    public class Article
    {
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ArticleID { get; set; }

        [Column(Order = 1), Key, ForeignKey("Author")]
        public Guid UserID { get; set; }

        [ForeignKey("Picture")]
        public Guid? PictureID { get; set; }

        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Content { get; set; }
        public List<string> Sources { get; set; }
        
        public virtual User Author { get; set; }
        public virtual Picture Picture { get; set; }
    }
}