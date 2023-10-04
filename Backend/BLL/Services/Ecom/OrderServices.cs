using AutoMapper;
using BLL.DTOs.Ecom;
using DAL.Models.Ecom;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Ecom
{
    public class OrderServices
    {
        public static OrderDTO Insert(OrderDTO team)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Order>(team);

            var info = DataAccessFactory.OrderData().Insert(mapped);

      
            var cfgg = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapperr = new Mapper(cfgg);
            var mappedd = mapperr.Map<OrderDTO>(info);
            return mappedd;
        }

        public static List<OrderDTO> GetAll()
        {
            var data = DataAccessFactory.OrderData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderDTO>>(data);
            return mapped;
        }

        public static OrderDTO GetById(int id)
        {
            var data = DataAccessFactory.OrderData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDTO>(data);
            return mapped;
        }

        public static OrderDTO Update(OrderDTO team)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Order>(team);

            var info = DataAccessFactory.OrderData().Update(mapped);

            var cfgg = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapperr = new Mapper(cfgg);
            var mappedd = mapperr.Map<OrderDTO>(info);
            return mappedd;
        }

    }
}
