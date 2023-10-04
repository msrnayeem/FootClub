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
    internal class CustomerRepo : Repo, IRepo<Customer, int, bool>
    {
        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }
        public bool Update(Customer player)
        {
            var exst = Get(player.Id);
            db.Entry(exst).CurrentValues.SetValues(player);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var data = db.Customers.Find(id);
            db.Customers.Remove(data);
            return db.SaveChanges() > 0;
        }

        public bool Insert(Customer player)
        {
            db.Customers.Add(player);
            if (db.SaveChanges() > 0)
            {
                LoginInfo loginInfo = new LoginInfo
                {
                    Email = player.Email,
                    Password = player.Password,
                    TableName = "Customers",
                    UserId = player.Id
                };
                db.LoginInfos.Add(loginInfo);

                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    var data = db.Customers.Find(player.Id);
                    db.Customers.Remove(data);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public List<Customer> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
