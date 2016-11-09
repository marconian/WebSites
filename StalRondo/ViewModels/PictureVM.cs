using StalRondo.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StalRondo.ViewModels
{
    public class PictureVM
    {
        public int HorseID { get; set; }
        public IEnumerable<Picture> Pictures { get; set; }
        public List<SelectListItem> Herd { get; set; }
    }
}