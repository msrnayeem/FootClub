using DAL.Models;
using DAL.Models.Ecom;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MFCContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<Injury> Injuries { get; set; }
        public DbSet<Assist> Assists { get; set; }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }

        
        /// Nayeem
        
        public DbSet<Player> Players { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<LoginInfo> LoginInfos { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderCart> OrderCarts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OTP> OTPs { get; set; }
    }
}
