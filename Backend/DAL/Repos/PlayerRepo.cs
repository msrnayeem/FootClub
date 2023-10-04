using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    //Nayeem
    internal class PlayerRepo : Repo, IRepo<Player, int, bool>
    {
        public List<Player> GetAll()
        {
            return db.Players.ToList();
        }

        public Player Get(int id)
        {
            return db.Players.Find(id);
        }
        public bool Update(Player player)
        {
            var exst = Get(player.Id);
            db.Entry(exst).CurrentValues.SetValues(player);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var data = db.Players.Find(id);
            db.Players.Remove(data);
            return db.SaveChanges() > 0;
        }

        public bool Insert(Player player)
        {
            db.Players.Add(player);
            if(db.SaveChanges() > 0){
                LoginInfo loginInfo = new LoginInfo
                {
                    Email = player.Email,
                    Password = player.Password,
                    TableName = "Players",
                    UserId = player.Id
                };
                db.LoginInfos.Add(loginInfo);

                if(db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    var data = db.Players.Find(player.Id);
                    db.Players.Remove(data);
                    return false;
                }
            }
            else
            {
                return false;
            }
           
        }

        public List<Player> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
