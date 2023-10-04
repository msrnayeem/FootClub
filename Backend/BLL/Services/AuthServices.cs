using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthServices
    {
        public static TokenDTO Authenticate(string uname, string pass)
        {

            var res = DataAccessFactory.AuthData().Authenticate(uname, pass);
            if (res)
            {
                var token = new Token
                {
                    UserEmail = uname,
                    CreatedAt = DateTime.Now,
                    Tkey = Guid.NewGuid().ToString()
                };
                var ret = DataAccessFactory.TokenData().Insert(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }

            }
            return null;
        }
        public static bool IsTokenValid(string tkey)
        {
            var exst = DataAccessFactory.TokenData().Get(tkey);
            if (exst != null && exst.ExpiredAt == null)
            {
                return true;
            }
            return false;
        }

        public static bool Logout(string tkey)
        {
            var exst = DataAccessFactory.TokenData().Get(tkey);
            exst.ExpiredAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(exst) != null)
            {
                return true;
            }
            return false;
        }

        public static bool IsAdmin(string tkey)
        {
            var data = DataAccessFactory.TokenData().Get(tkey);
            var check = DataAccessFactory.LoginData().Get(data.UserEmail);
            if (check.TableName.Equals("Users"))
            {
                return true;
            }
            return false;
        }

        public static string CheckTable(string tkey)
        {
            var data = DataAccessFactory.TokenData().Get(tkey);
            var check = DataAccessFactory.LoginData().Get(data.UserEmail);
            return check.TableName;
        }
    }
}
