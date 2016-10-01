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
    using Utilities;

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
                new Horse{HorseID=1, Name="At Last Oneliner", BirthDate=DateTime.Now, Gender=Gender.Stallion },
                new Horse{HorseID=2, Name="Casperhofs Freddy", BirthDate=DateTime.Now, Gender=Gender.Stallion },
                new Horse{HorseID=3, Name="Colbeach Inkerman", BirthDate=DateTime.Now, Gender=Gender.Stallion },
                new Horse{HorseID=4, Name="Gelpenbergs Sarina", BirthDate=DateTime.Now, Gender=Gender.Mare },
                new Horse{HorseID=5, Name="Nilanthoeves Zippo", BirthDate=DateTime.Now, Gender=Gender.Stallion },
                new Horse{HorseID=6, Name="Springstars Alexia", BirthDate=DateTime.Now, Gender=Gender.Mare },
                new Horse{HorseID=7, Name="Turfhorst Mandy", BirthDate=DateTime.Now, Gender=Gender.Mare },
                new Horse{HorseID=8, Name="Turfhorst Mona Lisa", BirthDate=DateTime.Now, Gender=Gender.Mare },
                new Horse{HorseID=9, Name="Wolbergs Bart", BirthDate=DateTime.Now, Gender=Gender.Stallion },
                new Horse{HorseID=10, Name="Wolbergs Jeroen", BirthDate=DateTime.Now, Gender=Gender.Stallion },
                new Horse{HorseID=11, Name="Woldbergs Rachel", BirthDate=DateTime.Now, Gender=Gender.Mare }
            };
            herd.ForEach(s => context.Herd.AddOrUpdate(s));
            context.SaveChanges();

            var genealogytree = new List<Genealogy>
            {
                new Genealogy{HorseID=1, FatherID=2, MotherID=4},
                new Genealogy{HorseID=2, FatherID=3, MotherID=6},
                new Genealogy{HorseID=4, FatherID=5, MotherID=7},
                new Genealogy{HorseID=5, FatherID=9, MotherID=8},
                new Genealogy{HorseID=7, FatherID=10, MotherID=11}
            };
            genealogytree.ForEach(s => context.GenealogyTree.AddOrUpdate(s));
            context.SaveChanges();

            var gallery = new List<Picture>
            {
                new Picture{HorseID=1, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\At_Last_Oneliner.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=2, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Casperhofs_Freddy.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=3, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Colbeach_Inkerman.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=4, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Gelpenbergs_Sarina.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=5, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Nilanthoeves_ Zippo.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=6, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Springstars_Alexia.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=7, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Turfhorst_Mandy.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=8, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Turfhorst_Mona_Lisa.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=9, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Wolbergs_Bart.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=10, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Wolbergs_Jeroen.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=11, Description="", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Woldbergs_Rachel.jpg"), ImageFormat.Jpeg) },
            };

            gallery.ForEach(s => context.Pictures.AddOrUpdate(s));
            context.SaveChanges();

            herd.ForEach(h => h.ProfilePictureID = context.Pictures.FirstOrDefault(p => p.HorseID == h.HorseID).PictureID);
            herd.ForEach(s => context.Herd.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
