using DAL.Interfaces;
using DAL.Models.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Ecom
{
    internal class OrderCartRepo : Repo, IRepo<OrderCart, int, bool>
    {
        public List<OrderCart> GetAll()
        {
            return db.OrderCarts.ToList();
        }

        public OrderCart Get(int id)
        {
            return db.OrderCarts.Find(id);
        }
        public bool Update(OrderCart data)
        {
            var exst = Get(data.Id);
            db.Entry(exst).CurrentValues.SetValues(data);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var data = db.OrderCarts.Find(id);
            db.OrderCarts.Remove(data);
            return db.SaveChanges() > 0;
        }

        public bool Insert(OrderCart data)
        {
            db.OrderCarts.Add(data);
            return db.SaveChanges() > 0;
        }

        public OrderCart Change(int id, int customerId, int quantity)
        {
            var data = db.OrderCarts.Find(id);
            data.CustomerId = customerId;
            data.Quantity = quantity;
            db.SaveChanges();

            return data;
        }

        public List<OrderCart> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
