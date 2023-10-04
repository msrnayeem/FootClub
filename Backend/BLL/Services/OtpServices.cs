using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OtpServices
    {
        public static int SendOtp(string email)
        {
            var data = DataAccessFactory.LoginData().Get(email);
            if (data != null)
            {
                Random random = new Random();
                int randomNumber = random.Next(100000, 999999);

                OTP op = new OTP
                {
                    Email = email,
                    Otp = randomNumber,
                    CreatedAt = DateTime.Now
                };

                var dataa = DataAccessFactory.OTPData().Insert(op);
                if(dataa != null)
                {
                    return dataa.Otp;
                }
            }
            return 0;
        }

        public static bool MatchOtp(int otp, string email)
        {
            var data = DataAccessFactory.OTPData().Get(email);
            if (data.Otp == otp)
            {
                var n = DataAccessFactory.OTPData().Delete(email);
                if (n != null)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public static bool ChangePassword(string email, string password)
        {
            var data = DataAccessFactory.LoginData().Get(email);
            if (data != null)
            {
                LoginInfo logininfo = new LoginInfo
                {
                    Id = data.Id,
                    Email = email,
                    TableName = data.TableName,
                    Password = password,
                    UserId = data.UserId
                };
                var res = DataAccessFactory.LoginData().Update(logininfo);
                if (res != null)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
