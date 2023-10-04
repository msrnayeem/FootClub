using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.Ecom;
using DAL;
using DAL.Models;
using DAL.Models.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProfileServices
    {
        public static UserDTO GetUserData(string tkey)
        {
            var data = DataAccessFactory.TokenData().Get(tkey);
            var check = DataAccessFactory.LoginData().Get(data.UserEmail);

                var dataa = DataAccessFactory.UserData().Get(check.UserId);
                var cfg = new MapperConfiguration(c => {
                    c.CreateMap<User, UserDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<UserDTO>(dataa);
                return mapped;

        }
        public static PlayerDTO GetPlayerData(string tkey)
        {
            var data = DataAccessFactory.TokenData().Get(tkey);
            var check = DataAccessFactory.LoginData().Get(data.UserEmail);
            
                var dataa = DataAccessFactory.PlayerData().Get(check.UserId);
                var cfg = new MapperConfiguration(c => {
                    c.CreateMap<Player, PlayerDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<PlayerDTO>(dataa);
                return mapped;
           
        } 
        public static CustomerDTO GetCustomerData(string tkey)
        {
            var data = DataAccessFactory.TokenData().Get(tkey);
            var check = DataAccessFactory.LoginData().Get(data.UserEmail);
            
                var dataa = DataAccessFactory.CustomerData().Get(check.UserId);
                var cfg = new MapperConfiguration(c => {
                    c.CreateMap<Customer, CustomerDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<CustomerDTO>(dataa);
                return mapped;
           
        }

    }
}
