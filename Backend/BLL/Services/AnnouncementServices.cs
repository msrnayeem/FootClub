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
    public class AnnouncementServices
    {
        public static bool Insert(AnnouncementDTO announcement)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<AnnouncementDTO, Announcement>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Announcement>(announcement);

            return DataAccessFactory.AnnouncementData().Insert(mapped);
        }

        public static List<AnnouncementDTO> GetAll()
        {
            var data = DataAccessFactory.AnnouncementData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Announcement, AnnouncementDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AnnouncementDTO>>(data);
            return mapped;
        }

        public static List<AnnouncementDTO> GetAllByUserId(int id)
        {
            var users = DataAccessFactory.AnnouncementData().GetAll();
            var data = from u in users
                       where u.UserID == id
                       select u;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Announcement, AnnouncementDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AnnouncementDTO>>(data);
            return mapped;
        }

        public static AnnouncementDTO GetById(int id)
        {
            var data = DataAccessFactory.AnnouncementData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Announcement, AnnouncementDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AnnouncementDTO>(data);
            return mapped;
        }

        public static bool Update(AnnouncementDTO announcement)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<AnnouncementDTO, Announcement>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Announcement>(announcement);

            return DataAccessFactory.AnnouncementData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.AnnouncementData().Delete(id);
        }
    }
}
