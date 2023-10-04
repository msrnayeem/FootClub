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
    public class RatingServices
    {
        public static bool Insert(RatingDTO rating)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<RatingDTO, Rating>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Rating>(rating);

            return DataAccessFactory.RatingData().Insert(mapped);
        }

        public static List<RatingDTO> GetAll()
        {
            var data = DataAccessFactory.RatingData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Rating, RatingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<RatingDTO>>(data);
            return mapped;
        }

        public static List<RatingDTO> GetAllByUserId(int id)
        {
            var users = DataAccessFactory.RatingData().GetAll();
            var data = from u in users
                       where u.UserId == id
                       select u;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Rating, RatingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<RatingDTO>>(data);
            return mapped;
        }

        public static RatingDTO GetById(int id)
        {
            var data = DataAccessFactory.RatingData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Rating, RatingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<RatingDTO>(data);
            return mapped;
        }

        public static List<RatingDTO> GetTop()
        {
            var players = DataAccessFactory.RatingData().GetAll();
            var data = from p in players
                       orderby p.Rating_point descending
                       select p;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Rating, RatingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<RatingDTO>>(data);
            return mapped;
        }

        public static bool Update(RatingDTO rating)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<RatingDTO, Rating>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Rating>(rating);

            return DataAccessFactory.RatingData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.RatingData().Delete(id);
        }
    }
}
