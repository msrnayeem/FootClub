using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AssistRepo : Repo, IRepo<Assist, int, bool>
    {
        public bool Insert(Assist assist)
        {
            db.Assists.Add(assist);
            return db.SaveChanges() > 0;

        }

        public List<Assist> GetAll()
        {
            return db.Assists.ToList();
        }

        public Assist Get(int id)
        {
            var data = db.Assists.Find(id);
            return data;
        }

        public bool Update(Assist assist)
        {
            var exst = Get(assist.Id);
            db.Entry(exst).CurrentValues.SetValues(assist);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Assists.Find(id);
            db.Assists.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Assist> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
