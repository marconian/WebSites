namespace StalRondo.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using Utilities;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.StableContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAL.StableContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.UserStore.RemoveRange(context.UserStore);
            context.Herd.RemoveRange(context.Herd);
            context.GenealogyTree.RemoveRange(context.GenealogyTree);
            context.Pictures.RemoveRange(context.Pictures);
            context.NewsPaper.RemoveRange(context.NewsPaper);
            context.SaveChanges();

            var userStore = new List<User>
            {
                new User {FirstName="Marco", SurName="Flier", Email="marcoflier@gmail.com", PasswordHash=Password.GetHash("Welkom01") },
                new User {FirstName="Jan", SurName="Flier", Email="janflier@stalrondo.nl", PasswordHash=Password.GetHash("Welkom02") },
                new User {FirstName="Jaron", SurName="Flier", Email="jaronflier@stalrondo.nl", PasswordHash=Password.GetHash("Welkom03") }
            };
            userStore.ForEach(u => context.UserStore.AddOrUpdate(u));
            context.SaveChanges();

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
                new Picture{HorseID=1, Description="Non laboro, inquit, de nomine.", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\At_Last_Oneliner.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=2, Description="Varietates autem iniurasque fortunae facile veteres philosophorum praeceptis instituta vita superabat.", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Casperhofs_Freddy.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=3, Description="Eorum enim est haec querela, qui sibi cari sunt seseque diligunt.", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Colbeach_Inkerman.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=4, Description="Eiuro, inquit adridens, iniquum, hac quidem de re.", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Gelpenbergs_Sarina.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=5, Description="Bona autem corporis huic sunt, quod posterius posui, similiora.", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Nilanthoeves_ Zippo.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=6, Description="Totum autem id externum est, et quod externum, id in casu est.", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Springstars_Alexia.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=7, Description="Sed fac ista esse non inportuna; Tu vero, inquam, ducas licet, si sequetur; Illi enim inter se dissentiunt. Si longus, levis.", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Turfhorst_Mandy.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=8, Description="Ergo in utroque exercebantur, eaque disciplina effecit tantam illorum utroque in genere dicendi copiam.", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Turfhorst_Mona_Lisa.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=9, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Wolbergs_Bart.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=10, Description="At certe gravius. Ego quoque, inquit, didicerim libentius si quid attuleris, quam te reprehenderim.", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Wolbergs_Jeroen.jpg"), ImageFormat.Jpeg) },
                new Picture{HorseID=11, Description="Idemque diviserunt naturam hominis in animum et corpus.", Data=ImgBase.ImageToByte(Image.FromFile(@"C:\GitHub\WebSites\StalRondo\Images\Woldbergs_Rachel.jpg"), ImageFormat.Jpeg) },
            };

            foreach(string filename in Directory.GetFiles(@"C:\GitHub\WebSites\StalRondo\Images\random"))
            {
                gallery.Add(
                    new Picture {
                        HorseID = 1,
                        Description = "Bona autem corporis huic sunt, quod posterius posui, similiora.",
                        Data = ImgBase.ImageToByte(Image.FromFile(filename), 
                        ImageFormat.Jpeg) }
                    );
            }

            gallery.ForEach(s => context.Pictures.AddOrUpdate(s));
            context.SaveChanges();

            herd.ForEach(h => h.ProfilePictureID = context.Pictures.FirstOrDefault(p => p.HorseID == h.HorseID).PictureID);
            herd.ForEach(s => context.Herd.AddOrUpdate(s));
            context.SaveChanges();

            var newsPaper = new List<Article>
            {
                new Article {UserID=context.UserStore.FirstOrDefault(u => u.Email == "marcoflier@gmail.com").UserID, Title="Waar een wil is, is een weg...", PublishDate=DateTime.Now, Sources=new List<string>(),
                    Content=@"
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. <i>Nunc agendum est subtilius.</i> At certe gravius. Ego quoque, inquit, didicerim libentius si quid attuleris, quam te reprehenderim. Idemque diviserunt naturam hominis in animum et corpus. </p>

                        <h2>Non laboro, inquit, de nomine.</h2>

                        <p>Tum Piso: Quoniam igitur aliquid omnes, quid Lucius noster? <b>Duo Reges: constructio interrete.</b> Egone non intellego, quid sit don Graece, Latine voluptas? An ea, quae per vinitorem antea consequebatur, per se ipsa curabit? Negat enim summo bono afferre incrementum diem. Compensabatur, inquit, cum summis doloribus laetitia. Magni enim aestimabat pecuniam non modo non contra leges, sed etiam legibus partam. Tollenda est atque extrahenda radicitus. Scaevola tribunus plebis ferret ad plebem vellentne de ea re quaeri. Sed residamus, inquit, si placet. </p>

                        <ol>
	                        <li>Varietates autem iniurasque fortunae facile veteres philosophorum praeceptis instituta vita superabat.</li>
	                        <li>Eorum enim est haec querela, qui sibi cari sunt seseque diligunt.</li>
                        </ol>


                        <ul>
	                        <li>Bona autem corporis huic sunt, quod posterius posui, similiora.</li>
	                        <li>Ut ad minora veniam, mathematici, poëtae, musici, medici denique ex hac tamquam omnium artificum officina profecti sunt.</li>
	                        <li>Eiuro, inquit adridens, iniquum, hac quidem de re;</li>
	                        <li>Callipho ad virtutem nihil adiunxit nisi voluptatem, Diodorus vacuitatem doloris.</li>
	                        <li>Sed ne, dum huic obsequor, vobis molestus sim.</li>
	                        <li>Totum autem id externum est, et quod externum, id in casu est.</li>
                        </ul>


                        <blockquote class='blockquote' cite='http://loripsum.net'>
	                        At enim hic etiam dolore.
                        </blockquote>


                        <p>Sed fac ista esse non inportuna; Tu vero, inquam, ducas licet, si sequetur; <i>Illi enim inter se dissentiunt.</i> Si longus, levis. </p>

                        <p>Qui-vere falsone, quaerere mittimus-dicitur oculis se privasse; Etiam beatissimum? Nescio quo modo praetervolavit oratio. <i>Tollenda est atque extrahenda radicitus.</i> <b>Quod totum contra est.</b> Etenim semper illud extra est, quod arte comprehenditur. Zenonis est, inquam, hoc Stoici. <a href='http://loripsum.net/' target='_blank'>Quae cum dixisset, finem ille.</a> </p>

                        <h3>Ergo in utroque exercebantur, eaque disciplina effecit tantam illorum utroque in genere dicendi copiam.</h3>

                        <p>Ex rebus enim timiditas, non ex vocabulis nascitur. <i>Sed nimis multa.</i> Immo videri fortasse. Quae animi affectio suum cuique tribuens atque hanc, quam dico. Si quae forte-possumus. Ab hoc autem quaedam non melius quam veteres, quaedam omnino relicta. Bonum patria: miserum exilium. </p>"
                },
                new Article {UserID=context.UserStore.FirstOrDefault(u => u.Email == "marcoflier@gmail.com").UserID, Title="2e plaats is niet genoeg", PublishDate=DateTime.Now, Sources=new List<string>(),
                    PictureID = context.Pictures.FirstOrDefault().PictureID,
                    Content=@"<h1>Nec lapathi suavitatem acupenseri Galloni Laelius anteponebat, sed suavitatem ipsam neglegebat;</h1>

                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. <i>Nunc agendum est subtilius.</i> At certe gravius. Ego quoque, inquit, didicerim libentius si quid attuleris, quam te reprehenderim. Idemque diviserunt naturam hominis in animum et corpus. </p>

                        <h2>Non laboro, inquit, de nomine.</h2>

                        <p>Tum Piso: Quoniam igitur aliquid omnes, quid Lucius noster? <b>Duo Reges: constructio interrete.</b> Egone non intellego, quid sit don Graece, Latine voluptas? An ea, quae per vinitorem antea consequebatur, per se ipsa curabit? Negat enim summo bono afferre incrementum diem. Compensabatur, inquit, cum summis doloribus laetitia. Magni enim aestimabat pecuniam non modo non contra leges, sed etiam legibus partam. Tollenda est atque extrahenda radicitus. Scaevola tribunus plebis ferret ad plebem vellentne de ea re quaeri. Sed residamus, inquit, si placet. </p>

                        <ol>
	                        <li>Varietates autem iniurasque fortunae facile veteres philosophorum praeceptis instituta vita superabat.</li>
	                        <li>Eorum enim est haec querela, qui sibi cari sunt seseque diligunt.</li>
                        </ol>

                        <p>Sed fac ista esse non inportuna; Tu vero, inquam, ducas licet, si sequetur; <i>Illi enim inter se dissentiunt.</i> Si longus, levis. </p>

                        <p>Qui-vere falsone, quaerere mittimus-dicitur oculis se privasse; Etiam beatissimum? Nescio quo modo praetervolavit oratio. <i>Tollenda est atque extrahenda radicitus.</i> <b>Quod totum contra est.</b> Etenim semper illud extra est, quod arte comprehenditur. Zenonis est, inquam, hoc Stoici. <a href='http://loripsum.net/' target='_blank'>Quae cum dixisset, finem ille.</a> </p>

                        <h3>Ergo in utroque exercebantur, eaque disciplina effecit tantam illorum utroque in genere dicendi copiam.</h3>

                        <p>Ex rebus enim timiditas, non ex vocabulis nascitur. <i>Sed nimis multa.</i> Immo videri fortasse. Quae animi affectio suum cuique tribuens atque hanc, quam dico. Si quae forte-possumus. Ab hoc autem quaedam non melius quam veteres, quaedam omnino relicta. Bonum patria: miserum exilium. </p>"
                },
                new Article {UserID=context.UserStore.FirstOrDefault(u => u.Email == "janflier@stalrondo.nl").UserID, Title="Voor de 6e keer winnar op een rij!", PublishDate=DateTime.Now, Sources=new List<string>(),
                    Content=@"<h1>Nec lapathi suavitatem acupenseri Galloni Laelius anteponebat, sed suavitatem ipsam neglegebat;</h1>

                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. <i>Nunc agendum est subtilius.</i> At certe gravius. Ego quoque, inquit, didicerim libentius si quid attuleris, quam te reprehenderim. Idemque diviserunt naturam hominis in animum et corpus. </p>

                        <h2>Non laboro, inquit, de nomine.</h2>

                        <p>Tum Piso: Quoniam igitur aliquid omnes, quid Lucius noster? <b>Duo Reges: constructio interrete.</b> Egone non intellego, quid sit don Graece, Latine voluptas? An ea, quae per vinitorem antea consequebatur, per se ipsa curabit? Negat enim summo bono afferre incrementum diem. Compensabatur, inquit, cum summis doloribus laetitia. Magni enim aestimabat pecuniam non modo non contra leges, sed etiam legibus partam. Tollenda est atque extrahenda radicitus. Scaevola tribunus plebis ferret ad plebem vellentne de ea re quaeri. Sed residamus, inquit, si placet. </p>

                        <blockquote cite='http://loripsum.net'>
	                        At enim hic etiam dolore.
                        </blockquote>


                        <p>Sed fac ista esse non inportuna; Tu vero, inquam, ducas licet, si sequetur; <i>Illi enim inter se dissentiunt.</i> Si longus, levis. </p>

                        <p>Qui-vere falsone, quaerere mittimus-dicitur oculis se privasse; Etiam beatissimum? Nescio quo modo praetervolavit oratio. <i>Tollenda est atque extrahenda radicitus.</i> <b>Quod totum contra est.</b> Etenim semper illud extra est, quod arte comprehenditur. Zenonis est, inquam, hoc Stoici. <a href='http://loripsum.net/' target='_blank'>Quae cum dixisset, finem ille.</a> </p>

                        <h3>Ergo in utroque exercebantur, eaque disciplina effecit tantam illorum utroque in genere dicendi copiam.</h3>

                        <p>Ex rebus enim timiditas, non ex vocabulis nascitur. <i>Sed nimis multa.</i> Immo videri fortasse. Quae animi affectio suum cuique tribuens atque hanc, quam dico. Si quae forte-possumus. Ab hoc autem quaedam non melius quam veteres, quaedam omnino relicta. Bonum patria: miserum exilium. </p>"
                }
            };
            newsPaper.ForEach(a => context.NewsPaper.AddOrUpdate(a));
            context.SaveChanges();
        }
    }
}
