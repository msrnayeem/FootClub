using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs.Ecom;
using DAL.Models.Ecom;

namespace BLL.Services.Ecom
{
    public class CustomerServices
    {
        public static bool Insert(CustomerDTO player)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Customer>(player);

            return DataAccessFactory.CustomerData().Insert(mapped);
        }

        public static List<CustomerDTO> GetAll()
        {
            var data = DataAccessFactory.CustomerData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CustomerDTO>>(data);
            return mapped;
        }

        public static CustomerDTO GetById(int id)
        {
            var data = DataAccessFactory.CustomerData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CustomerDTO>(data);
            return mapped;
        }


        public static bool Update(CustomerDTO player)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Customer>(player);

            return DataAccessFactory.CustomerData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CustomerData().Delete(id);
        }
    }
}
