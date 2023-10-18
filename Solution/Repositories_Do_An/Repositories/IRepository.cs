using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{

    public interface IRepository<T> where T : class
    {
        List<T> getAll();
        T read(int id);
        T read(string name);
        bool create(T entity);
        bool update(T entity);
        bool delete(T entity);
    }
}
