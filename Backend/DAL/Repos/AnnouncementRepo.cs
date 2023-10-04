using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AnnouncementRepo : Repo, IRepo<Announcement, int, bool>
    {
            public bool Insert(Announcement announcement)
            {
                db.Announcements.Add(announcement);
                return db.SaveChanges() > 0;
            }

            public List<Announcement> GetAll()
            {
                return db.Announcements.ToList();
            }

            public Announcement Get(int id)
            {
                var data = db.Announcements.Find(id);
                return data;
            }

            public bool Update(Announcement announcement)
            {
                var exst = Get(announcement.Id);
                db.Entry(exst).CurrentValues.SetValues(announcement);
                return db.SaveChanges() > 0;
            }

            public bool Delete(int id)
            {
                var data = db.Announcements.Find(id);
                db.Announcements.Remove(data);
                return db.SaveChanges() > 0;
            }

        public List<Announcement> GetByCategorys(int id)
        {
            throw new NotImplementedException();
        }
    }
}
