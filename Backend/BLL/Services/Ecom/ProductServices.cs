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
using DAL.Repos.Ecom;
namespace BLL.Services.Ecom
{
    public class ProductServices
    {
        public static bool Insert(ProductDTO team)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Product>(team);

            return DataAccessFactory.ProductData().Insert(mapped);
        }

        public static List<ProductDTO> GetAll()
        {
            var data = DataAccessFactory.ProductData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ProductDTO>>(data);
            return mapped;
        }

        public static ProductDTO GetById(int id)
        {
            var data = DataAccessFactory.ProductData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;
        }

        public static bool Update(ProductDTO team)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ProductDTO, Team>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Product>(team);

            return DataAccessFactory.ProductData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ProductData().Delete(id);
        }

        public static ProductDTO GetByCategory(int categoryId)
        {
            var data = DataAccessFactory.ProductData().GetByCategorys(categoryId);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;
        }
    }
}
