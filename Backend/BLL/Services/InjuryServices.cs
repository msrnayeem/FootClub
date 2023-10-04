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
    public class InjuryServices
    {
        public static bool Insert(InjuryDTO injury)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<InjuryDTO, Injury>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Injury>(injury);

            return DataAccessFactory.InjuryData().Insert(mapped);
        }

        public static List<InjuryDTO> GetAll()
        {
            var data = DataAccessFactory.InjuryData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Injury, InjuryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<InjuryDTO>>(data);
            return mapped;
        }

        public static List<InjuryDTO> GetAllByUserId(int id)
        {
            var users = DataAccessFactory.InjuryData().GetAll();
            var data = from u in users
                       where u.UserId == id
                       select u;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Injury, InjuryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<InjuryDTO>>(data);
            return mapped;
        }

        public static InjuryDTO GetById(int id)
        {
            var data = DataAccessFactory.InjuryData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Injury, InjuryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<InjuryDTO>(data);
            return mapped;
        }

        public static bool Update(InjuryDTO injury)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<InjuryDTO, Injury>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Injury>(injury);

            return DataAccessFactory.InjuryData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.InjuryData().Delete(id);
        }
    }
}
