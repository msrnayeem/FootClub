using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RatingRepo : Repo, IRepo<Rating, int, bool>
    {
        public bool Insert(Rating rating)
        {
            db.Ratings.Add(rating);
            return db.SaveChanges() > 0;
        }

        public List<Rating> GetAll()
        {
            return db.Ratings.ToList();
        }

        public Rating Get(int id)
        {
            var data = db.Ratings.Find(id);
            return data;
        }

        public bool Update(Rating rating)
        {
            var exst = Get(rating.Id);
            db.Entry(exst).CurrentValues.SetValues(rating);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Ratings.Find(id);
            db.Ratings.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Rating> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
