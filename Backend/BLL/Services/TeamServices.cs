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
    public class TeamServices
    {
        public static bool Insert(TeamDTO team)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<TeamDTO, Team>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Team>(team);

            return DataAccessFactory.TeamData().Insert(mapped);
        }

        public static List<TeamDTO> GetAll()
        {
            var data = DataAccessFactory.TeamData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Team, TeamDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TeamDTO>>(data);
            return mapped;
        }

        public static List<TeamDTO> GetAllByUserId(int id)
        {
            var users = DataAccessFactory.TeamData().GetAll();
            var data = from u in users
                       where u.UserId == id
                       select u;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Team, TeamDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TeamDTO>>(data);
            return mapped;
        }

        public static TeamDTO GetById(int id)
        {
            var data = DataAccessFactory.TeamData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Team, TeamDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TeamDTO>(data);
            return mapped;
        }

        public static bool Update(TeamDTO team)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<TeamDTO, Team>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Team>(team);

            return DataAccessFactory.TeamData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TeamData().Delete(id);
        }
    }
}
