using DAL.Interfaces;
using DAL.Models;
using DAL.Models.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Ecom
{
    internal class CategoryRepo : Repo, IRepo<Category, int, bool>
    {
        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }
        public bool Update(Category category)
        {
            var exst = Get(category.Id);
            db.Entry(exst).CurrentValues.SetValues(category);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var data = db.Categories.Find(id);
            db.Categories.Remove(data);
            return db.SaveChanges() > 0;
        }

        public bool Insert(Category product)
        {
            db.Categories.Add(product);
            return db.SaveChanges() > 0;
        }
        public List<Category> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }

    }
}
