using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class GoalRepo : Repo, IRepo<Goal, int, bool>
    {
        public bool Insert(Goal goal)
        {
            db.Goals.Add(goal);
            return db.SaveChanges() > 0;
        }

        public List<Goal> GetAll()
        {
            return db.Goals.ToList();
        }

        public Goal Get(int id)
        {
            var data = db.Goals.Find(id);
            return data;
        }

        public bool Update(Goal goal)
        {
            var exst = Get(goal.Id);
            db.Entry(exst).CurrentValues.SetValues(goal);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Goals.Find(id);
            db.Goals.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Goal> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
