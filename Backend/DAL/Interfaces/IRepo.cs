using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<TYPE, ID, RET>
    {
        List<TYPE> GetAll();
        TYPE Get(ID id);
        RET Insert(TYPE obj);
        RET Update(TYPE obj);
        RET Delete(ID id);
        List<TYPE> GetByCategorys(ID id);

    }
}
