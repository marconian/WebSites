namespace StalRondo.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StalRondo.DAL.StableContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StalRondo.DAL.StableContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var herd = new List<Horse>
            {
                new Horse{HorseID=1, Name="At Last Oneliner", BirthDate=DateTime.Now, Gender="Stalion"},
                new Horse{HorseID=2, Name="Casperhofs Freddy", BirthDate=DateTime.Now, Gender="Stalion"},
                new Horse{HorseID=3, Name="Colbeach Inkerman", BirthDate=DateTime.Now, Gender="Stalion"},
                new Horse{HorseID=4, Name="Gelpenbergs Sarina", BirthDate=DateTime.Now, Gender="Mare"},
                new Horse{HorseID=5, Name="Nilanthoeves Zippo", BirthDate=DateTime.Now, Gender="Stalion"},
                new Horse{HorseID=6, Name="Springstars Alexia", BirthDate=DateTime.Now, Gender="Mare"},
                new Horse{HorseID=7, Name="Turfhorst Mandy", BirthDate=DateTime.Now, Gender="Mare"},
                new Horse{HorseID=8, Name="Turfhorst Mona Lisa", BirthDate=DateTime.Now, Gender="Mare"},
                new Horse{HorseID=9, Name="Wolbergs Bart", BirthDate=DateTime.Now, Gender="Stalion"},
                new Horse{HorseID=10, Name="Wolbergs Jeroen", BirthDate=DateTime.Now, Gender="Stalion"},
                new Horse{HorseID=11, Name="Woldbergs Rachel", BirthDate=DateTime.Now, Gender="Mare"}
            };
            herd.ForEach(s => context.Herd.AddOrUpdate(s));
            context.SaveChanges();

            var gallery = new List<Picture>
            {
                new Picture{HorseID=1, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\At_Last_Oneliner.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=2, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Casperhofs_Freddy.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=3, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Colbeach_Inkerman.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=4, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Gelpenbergs_Sarina.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=5, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Nilanthoeves_ Zippo.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=6, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Springstars_Alexia.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=7, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Turfhorst_Mandy.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=8, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Turfhorst_Mona_Lisa.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=9, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Wolbergs_Bart.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=10, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Wolbergs_Jeroen.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=11, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"\Images\Woldbergs_Rachel.jpg"), ImageFormat.Jpeg) }
            };

            gallery.ForEach(s => context.Pictures.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
