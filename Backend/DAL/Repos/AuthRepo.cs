using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AuthRepo : Repo, IAuth<bool>
    {
        public bool Authenticate(string email, string password)
        {
            var data = db.LoginInfos.FirstOrDefault(l => l.Email.Equals(email)
            && l.Password.Equals(password));
            if (data != null) return true;
            return false;
        }
    }
}
