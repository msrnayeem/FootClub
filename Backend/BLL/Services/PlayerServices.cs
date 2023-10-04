using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PlayerServices
    {
        public static bool Insert(PlayerDTO player)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PlayerDTO, Player>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Player>(player);

            return DataAccessFactory.PlayerData().Insert(mapped);
        }
        
        public static List<PlayerDTO> GetAll()
        {
            var data = DataAccessFactory.PlayerData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Player, PlayerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PlayerDTO>>(data);
            return mapped;
        }

        public static PlayerDTO GetById(int id)
        {
            var data = DataAccessFactory.PlayerData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Player, PlayerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PlayerDTO>(data);
            return mapped;
        }


        public static bool Update(PlayerDTO player)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PlayerDTO, Player>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Player>(player);

            return DataAccessFactory.PlayerData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.PlayerData().Delete(id);
        }
    }
}
