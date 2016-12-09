using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
  public  interface IRepository<T>
    {
        bool DeleteData(int id);
        T GetById(int id);
        List<T> GetDataList(string filter = null, string sort = null, bool isSortDirAsc = false);
        bool InsertData(T t);
        bool UpdateData(T t);
    }
}
