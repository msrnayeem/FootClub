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
    public class MatchServices
    {
        public static bool Insert(MatchDTO match)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<MatchDTO, Match>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Match>(match);

            return DataAccessFactory.MatchData().Insert(mapped);
        }

        public static List<MatchDTO> GetAll()
        {
            var data = DataAccessFactory.MatchData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Match, MatchDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<MatchDTO>>(data);
            return mapped;
        }

        public static List<MatchDTO> GetAllByUserId(int id)
        {
            var users = DataAccessFactory.MatchData().GetAll();
            var data = from u in users
                       where u.UserId == id
                       select u;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Match, MatchDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<MatchDTO>>(data);
            return mapped;
        }

        public static List<MatchDTO> GetAllForPlayer(int id)
        {
            var matches = DataAccessFactory.MatchData().GetAll();
            var teams = DataAccessFactory.TeamData().GetAll();
            var data = from m in matches
                       join t in teams on m.Id equals t.MatchId
                       where t.PlayerId == id
                       select m;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Match, MatchDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<MatchDTO>>(data);
            return mapped;
        }

        public static MatchDTO GetById(int id)
        {
            var data = DataAccessFactory.MatchData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Match, MatchDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<MatchDTO>(data);
            return mapped;
        }

        public static bool Update(MatchDTO match)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<MatchDTO, Match>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Match>(match);

            return DataAccessFactory.MatchData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.MatchData().Delete(id);
        }
    }
}
