using DAL.Interfaces;
using DAL.Models.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Ecom
{
    internal class OrderRepo:Repo, IRepo<Order, int, Order>
    {
        public List<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }
        public Order Update(Order data)
        {
            var exst = Get(data.Id);
            db.Entry(exst).CurrentValues.SetValues(data);
             db.SaveChanges();

            return data;
        }
        public Order Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order Insert(Order data)
        {
            db.Orders.Add(data);
             db.SaveChanges();
            return data;
        }

        public Order Change(int id, int customerId, int quantity)
        {
            var data = db.Orders.Find(id);
            data.CustomerId = customerId;
            data.Quantity = quantity;
            data.Status = "processing";
            db.SaveChanges();

            return data;
        }

        public List<Order> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
