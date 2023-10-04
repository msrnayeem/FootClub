using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class InjuryRepo : Repo, IRepo<Injury, int, bool>
    {
        public bool Insert(Injury injury)
        {
            db.Injuries.Add(injury);
            return db.SaveChanges() > 0;
        }

        public List<Injury> GetAll()
        {
            return db.Injuries.ToList();
        }

        public Injury Get(int id)
        {
            var data = db.Injuries.Find(id);
            return data;
        }

        public bool Update(Injury injury)
        {
            var exst = Get(injury.Id);
            db.Entry(exst).CurrentValues.SetValues(injury);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Injuries.Find(id);
            db.Injuries.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Injury> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
