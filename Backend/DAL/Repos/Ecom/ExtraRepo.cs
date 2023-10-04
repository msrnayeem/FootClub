using DAL.Interfaces;
using DAL.Models.Ecom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Ecom
{
    public class ExtraRepo 
    {
        public static MFCContext db = new MFCContext();
        public static List<Product> GetByCategorys(int categoryId)
        {
            return db.Products.Where(p => p.CategoryId == categoryId).ToList();

        }
    }
}
