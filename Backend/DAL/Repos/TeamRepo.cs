using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TeamRepo : Repo, IRepo<Team, int, bool>
    {
        public bool Insert(Team team)
        {
            db.Teams.Add(team);
            return db.SaveChanges() > 0;
        }

        public List<Team> GetAll()
        {
            return db.Teams.ToList();
        }

        public Team Get(int id)
        {
            var data = db.Teams.Find(id);
            return data;
        }

        public bool Update(Team team)
        {
            var exst = Get(team.Id);
            db.Entry(exst).CurrentValues.SetValues(team);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Teams.Find(id);
            db.Teams.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Team> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
