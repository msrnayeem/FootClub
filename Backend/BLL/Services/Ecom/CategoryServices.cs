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
    public class CategoryServices
    {
        public static bool Insert(CategoryDTO team)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CategoryDTO, Category>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Category>(team);

            return DataAccessFactory.CategoryData().Insert(mapped);
        }

        public static List<CategoryDTO> GetAll()
        {
            var data = DataAccessFactory.CategoryData().GetAll();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CategoryDTO>>(data);
            return mapped;
        }

        public static CategoryDTO GetById(int id)
        {
            var data = DataAccessFactory.CategoryData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CategoryDTO>(data);
            return mapped;
        }

        public static bool Update(CategoryDTO team)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CategoryDTO, Category>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Category>(team);

            return DataAccessFactory.CategoryData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CategoryData().Delete(id);
        }
    }
}
