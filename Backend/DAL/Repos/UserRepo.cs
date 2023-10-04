using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, bool>
    {
        public bool Insert(User user)
        {
            db.Users.Add(user);
            if(db.SaveChanges() > 0)
            {
                LoginInfo loginInfo = new LoginInfo
                {
                    Email = user.Email,
                    Password = user.Password,
                    TableName = "Users",
                    UserId = user.Id
                };
                db.LoginInfos.Add(loginInfo);
                if(db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    var data = db.Users.Find(user.Id);
                    db.Users.Remove(data);
                    return false;
                }
            }

            return false;

        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            var data = db.Users.Find(id);
            return data;
        }

        public bool Update(User user)
        {
            var exst = Get(user.Id);
            db.Entry(exst).CurrentValues.SetValues(user);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Users.Find(id);
            db.Users.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<User> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
