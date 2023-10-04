using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OtpRepo : Repo, IRepo<OTP, string, OTP>
    {
        public OTP Insert(OTP user)
        {
            db.OTPs.Add(user);
            db.SaveChanges();
            return user;
        }

        public List<OTP> GetAll()
        {
            throw new NotImplementedException();
        }

        public OTP Get(string email)
        {
            return db.OTPs.FirstOrDefault(l => l.Email.Equals(email));
        }

        public OTP Update(OTP user)
        {
            throw new NotImplementedException();
        }

        public OTP Delete(string email)
        {
            var data = Get(email);
            data.LastUpdatedAt = DateTime.Now;
            db.SaveChanges();
            return data;
        }

        public List<OTP> GetByCategorys(string id)
        {
            throw new NotImplementedException();
        }
    }
}
