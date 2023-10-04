using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MatchRepo : Repo, IRepo <Match, int, bool>
    {
        public bool Insert(Match match)
        {
            db.Matches.Add(match);
            return db.SaveChanges() > 0;
        }

        public List<Match> GetAll()
        {
            return db.Matches.ToList();
        }

        public Match Get(int id)
        {
            var data = db.Matches.Find(id);
            return data;
        }

        public bool Update(Match match)
        {
            var exst = Get(match.Id);
            db.Entry(exst).CurrentValues.SetValues(match);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Matches.Find(id);
            db.Matches.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Match> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
