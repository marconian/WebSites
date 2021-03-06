﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StalRondo.Models;
using System.Drawing;
using System.Drawing.Imaging;

namespace StalRondo.DAL
{
    public class StableInitializer : DropCreateDatabaseIfModelChanges<StableContext>
    {
        protected override void Seed(StableContext context)
        {
            //var herd = new List<Horse>
            //{
            //    new Horse{HorseID=1, GenealogyID=1, Name="At Last Oneliner", BirthDate=DateTime.Now, Gender="Stalion"},
            //    new Horse{HorseID=2, GenealogyID=2, Name="Casperhofs Freddy", BirthDate=DateTime.Now, Gender="Stalion"},
            //    new Horse{HorseID=3, GenealogyID=3, Name="Colbeach Inkerman", BirthDate=DateTime.Now, Gender="Stalion"},
            //    new Horse{HorseID=4, GenealogyID=4, Name="Gelpenbergs Sarina", BirthDate=DateTime.Now, Gender="Mare"},
            //    new Horse{HorseID=5, GenealogyID=5, Name="Nilanthoeves Zippo", BirthDate=DateTime.Now, Gender="Stalion"},
            //    new Horse{HorseID=6, GenealogyID=6, Name="Springstars Alexia", BirthDate=DateTime.Now, Gender="Mare"},
            //    new Horse{HorseID=7, GenealogyID=7, Name="Turfhorst Mandy", BirthDate=DateTime.Now, Gender="Mare"},
            //    new Horse{HorseID=8, GenealogyID=8, Name="Turfhorst Mona Lisa", BirthDate=DateTime.Now, Gender="Mare"},
            //    new Horse{HorseID=9, GenealogyID=9, Name="Wolbergs Bart", BirthDate=DateTime.Now, Gender="Stalion"},
            //    new Horse{HorseID=10, GenealogyID=10, Name="Wolbergs Jeroen", BirthDate=DateTime.Now, Gender="Stalion"},
            //    new Horse{HorseID=11, GenealogyID=11, Name="Woldbergs Rachel", BirthDate=DateTime.Now, Gender="Mare"}
            //};
            //herd.ForEach(s => context.Herd.Add(s));
            //context.SaveChanges();

            //var genealogytree = new List<Genealogy>
            //{
            //    new Genealogy{GenealogyID=1},
            //    new Genealogy{GenealogyID=2},
            //    new Genealogy{GenealogyID=3},
            //    new Genealogy{GenealogyID=4},
            //    new Genealogy{GenealogyID=5},
            //    new Genealogy{GenealogyID=6},
            //    new Genealogy{GenealogyID=7},
            //    new Genealogy{GenealogyID=8},
            //    new Genealogy{GenealogyID=9},
            //    new Genealogy{GenealogyID=10},
            //    new Genealogy{GenealogyID=11}
            //};
            //genealogytree.ForEach(s => context.GenealogyTree.Add(s));
            //context.SaveChanges();

            //var gallery = new List<Picture>
            //{
            //    new Picture{HorseID=1, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\At_Last_Oneliner.jpg"), ImageFormat.Jpeg) },
            //    new Picture{HorseID=2, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Casperhofs_Freddy.jpg"), ImageFormat.Jpeg) },
            //    new Picture{HorseID=3, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Colbeach_Inkerman.jpg"), ImageFormat.Jpeg) },
            //    new Picture{HorseID=4, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Gelpenbergs_Sarina.jpg"), ImageFormat.Jpeg) },
            //    new Picture{HorseID=5, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Nilanthoeves_ Zippo.jpg"), ImageFormat.Jpeg) },
            //    new Picture{HorseID=6, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Springstars_Alexia.jpg"), ImageFormat.Jpeg) },
            //    new Picture{HorseID=7, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Turfhorst_Mandy.jpg"), ImageFormat.Jpeg) },
            //    new Picture{HorseID=8, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Turfhorst_Mona_Lisa.jpg"), ImageFormat.Jpeg) },
            //    new Picture{HorseID=9, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Wolbergs_Bart.jpg"), ImageFormat.Jpeg) },
            //    new Picture{HorseID=10, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Wolbergs_Jeroen.jpg"), ImageFormat.Jpeg) },
            //    new Picture{HorseID=11, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Woldbergs_Rachel.jpg"), ImageFormat.Jpeg) }
            //};

            //gallery.ForEach(s => context.Pictures.Add(s));
            //context.SaveChanges();
        }
    }
}