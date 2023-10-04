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
    public class AssistServices
    {
        public static bool Insert(AssistDTO assist)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<AssistDTO, Assist>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Assist>(assist);

            return DataAccessFactory.AssistData().Insert(mapped);
        }

        public static List<AssistDTO> GetAll()
        {
            var data = DataAccessFactory.AssistData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Assist, AssistDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AssistDTO>>(data);
            return mapped;
        }

        public static List<AssistDTO> GetAllByUserId(int id)
        {
            var users = DataAccessFactory.AssistData().GetAll();
            var data = from u in users
                       where u.UserId == id
                       select u;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Assist, AssistDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AssistDTO>>(data);
            return mapped;
        }

        public static AssistDTO GetById(int id)
        {
            var data = DataAccessFactory.AssistData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Assist, AssistDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AssistDTO>(data);
            return mapped;
        }

        public static List<AssistDTO> GetTop()
        {
            var players = DataAccessFactory.AssistData().GetAll();
            var data = from p in players
                       orderby p.NoOfAssist descending
                       select p;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Assist, AssistDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AssistDTO>>(data);
            return mapped;
        }

        public static bool Update(AssistDTO assist)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<AssistDTO, Assist>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Assist>(assist);

            return DataAccessFactory.AssistData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.AssistData().Delete(id);
        }
    }
}
