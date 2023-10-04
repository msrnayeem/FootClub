using System;
using BLL.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;
using DAL;

namespace BLL.Services
{
    public class PaymentServices
    {
        public static bool Insert(PaymentDTO payment)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PaymentDTO, Payment>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Payment>(payment);

            return DataAccessFactory.PaymentData().Insert(mapped);
        }



        public static List<PaymentDTO> GetAll()
        {
            var data = DataAccessFactory.PaymentData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }

        public static List<PaymentDTO> GetAllByUserId(int id)
        {
            var users = DataAccessFactory.PaymentData().GetAll();
            var data = from u in users
                       where u.UserId == id
                       select u;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }

        public static List<PaymentDTO> GetAllByPlayerId(int id)
        {
            var users = DataAccessFactory.PaymentData().GetAll();
            var data = from u in users
                       where u.PlayerId == id
                       select u;
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }

        public static PaymentDTO GetById(int id)
        {
            var data = DataAccessFactory.PaymentData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PaymentDTO>(data);
            return mapped;
        }


        public static bool Update(PaymentDTO payment)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PaymentDTO, Payment>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Payment>(payment);

            return DataAccessFactory.PaymentData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.PaymentData().Delete(id);
        }
    }
}
