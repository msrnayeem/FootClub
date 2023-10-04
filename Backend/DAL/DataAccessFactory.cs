using DAL.Interfaces;
using DAL.Models;
using DAL.Models.Ecom;
using DAL.Repos;
using DAL.Repos.Ecom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
            public static IRepo<User, int, bool> UserData()
            {
                return new UserRepo();
            }

            public static IRepo<Announcement, int, bool> AnnouncementData()
            {
            return new AnnouncementRepo();
            }

        public static IRepo<Rating, int, bool> RatingData()
        {
            return new RatingRepo();
        }
        public static IRepo<Injury, int, bool> InjuryData()
        {
            return new InjuryRepo();
        }

        public static IRepo<Match, int, bool> MatchData()
        {
            return new MatchRepo();
        }

        public static IRepo<Team, int, bool> TeamData()
        {
            return new TeamRepo();
        }
        
        public static IRepo<Player, int, bool> PlayerData()
        {
            return new PlayerRepo();
        }

        public static IRepo<Assist, int, bool> AssistData()
        {
            return new AssistRepo();
        }
        public static IRepo<Payment, int, bool> PaymentData()
        {
            return new PaymentRepo();
        } 
        public static IRepo<Goal, int, bool> GoalData()
        {
            return new GoalRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new AuthRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }

        public static IRepo<LoginInfo, string, LoginInfo> LoginData()
        {
            return new LoginInfoRepo();
        }

        public static IRepo<OTP, string, OTP> OTPData()
        {
            return new OtpRepo();
        }
        //ecom
        public static IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();
        }

        public static IRepo<Category, int, bool> CategoryData()
        {
            return new CategoryRepo();
        }

        public static IRepo<Customer, int, bool> CustomerData()
        {
            return new CustomerRepo();
        }

        public static IRepo<Order, int, Order> OrderData()
        {
            return new OrderRepo();
        }
    }
}
