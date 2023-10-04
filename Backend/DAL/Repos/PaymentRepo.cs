using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PaymentRepo : Repo, IRepo<Payment, int, bool>
    {
        public bool Insert(Payment payment)
        {
            db.Payments.Add(payment);
            return db.SaveChanges() > 0;
        }
        public List<Payment> GetAll()
        {
            return db.Payments.ToList();
        }
        public Payment Get(int id)
        {
            return db.Payments.Find(id);
        }

        public bool Update(Payment payment)
        {
            var exst = Get(payment.Id);
            db.Entry(exst).CurrentValues.SetValues(payment);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var exst = db.Payments.Find(id);
            db.Payments.Remove(exst);
            return db.SaveChanges() > 0;
        }

        public List<Payment> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
