using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>> TGetAll();
        Task<T> TGetById(int id);
        Task<T> TCreate(T t);
        Task<T> TUpdate(T t);
        Task TDelete(int id);
    }
}
