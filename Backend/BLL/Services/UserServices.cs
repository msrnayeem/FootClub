using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BLL.Services
{
    public class UserServices
    {
        public static bool Insert(UserDTO user) 
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<User>(user);

            return DataAccessFactory.UserData().Insert(mapped);
        }

        public static List<UserDTO> GetAll() 
        {
            var data = DataAccessFactory.UserData().GetAll();
            var cfg = new MapperConfiguration(c=> {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;
        }

        public static UserDTO GetById(int id)
        {
            var data = DataAccessFactory.UserData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }

        public static bool Update(UserDTO user)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<User>(user);

            return DataAccessFactory.UserData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.UserData().Delete(id);
        }
    }
}
