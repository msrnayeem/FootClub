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
    internal class ProductRepo : Repo, IRepo<Product, int, bool>
    {
        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }
        public bool Update(Product product)
        {
            var exst = Get(product.Id);
            db.Entry(exst).CurrentValues.SetValues(product);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var data = db.Products.Find(id);
            db.Products.Remove(data);
            return db.SaveChanges() > 0;
        }

        public bool Insert(Product product)
        {
            db.Products.Add(product);
            return db.SaveChanges() > 0;
        }

        public int Quantity(int id, int quantity)
        {
            var data = db.Products.Find(id);
            data.Quantity = quantity;
            db.SaveChanges();

            return data.Quantity;
        }

        public  List<Product> GetByCategorys(int categoryId)
        {
            return db.Products.Where(p => p.CategoryId == categoryId).ToList();

        }
    }
}
