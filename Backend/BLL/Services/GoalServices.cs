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
    public class GoalServices
    {
        public static bool Insert(GoalDTO goal)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<GoalDTO, Goal>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Goal>(goal);

            return DataAccessFactory.GoalData().Insert(mapped);
        }

        public static List<GoalDTO> GetAll()
        {
            var data = DataAccessFactory.GoalData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Goal, GoalDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<GoalDTO>>(data);
            return mapped;
        }

        public static GoalDTO GetById(int id)
        {
            var data = DataAccessFactory.GoalData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Goal, GoalDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<GoalDTO>(data);
            return mapped;
        }

        public static List<GoalDTO> GetAllByUserId(int id)
        {
            var users = DataAccessFactory.GoalData().GetAll();
            var data = from u in users
                       where u.UserId == id
                       select u;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Goal, GoalDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<GoalDTO>>(data);
            return mapped;
        }

        public static List<GoalDTO> GetTop()
        {
            var players = DataAccessFactory.GoalData().GetAll();
            var data = from p in players
                       orderby p.NoOfGoal descending
                       select p;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Goal, GoalDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<GoalDTO>>(data);
            return mapped;
        }

        public static bool Update(GoalDTO goal)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<GoalDTO, Goal>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Goal>(goal);

            return DataAccessFactory.GoalData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.GoalData().Delete(id);
        }
    }
}
