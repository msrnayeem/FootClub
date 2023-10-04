using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LoginInfoRepo : Repo, IRepo<LoginInfo, string, LoginInfo>
    {
        public LoginInfo Insert(LoginInfo user)
        {
            throw new NotImplementedException();
        }

        public List<LoginInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public LoginInfo Get(string email)
        {
            return  db.LoginInfos.FirstOrDefault( l => l.Email.Equals(email));
        }

        public LoginInfo Update(LoginInfo user)
        {
            var data = Get(user.Email);
            db.Entry(data).CurrentValues.SetValues(user);
             db.SaveChanges();
            return data;
        }

        public LoginInfo Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<LoginInfo> GetByCategorys(string id)
        {
            throw new NotImplementedException();
        }
    }
}
