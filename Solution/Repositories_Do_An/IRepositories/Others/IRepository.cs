using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.IRepositories
{

    public interface IRepository<T> where T : class
    {
        List<T> getAll();
        T read(int id);
        bool create(T entity);
        bool update(T entity);
        bool delete(T entity);
    }
}
