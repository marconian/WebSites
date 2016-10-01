using StalRondo.DAL;
using StalRondo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StalRondo.ViewModels
{
    public class GenealogyTree
    {
        private StableContext db = new StableContext();
        public GenealogyTree(Genealogy horse, int level = 0)
        {

            Horse = horse;
            Level = level;
        }
        public Genealogy Horse { get; set; }
        public int Level { get; set; }

        public GenealogyTree Father {
            get
            {
                if (Horse.FatherID == null) return null;

                Genealogy horse = db.GenealogyTree.Find(Horse.FatherID);
                if (horse == null) return null;

                return new GenealogyTree(horse, Level + 1);
            }
        }
        public GenealogyTree Mother
        {
            get
            {
                if (Horse.MotherID == null) return null;

                Genealogy horse = db.GenealogyTree.Find(Horse.MotherID);
                if (horse == null) return null;

                return new GenealogyTree(horse, Level + 1);
            }
        }
    }
}