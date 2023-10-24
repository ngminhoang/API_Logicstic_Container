using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.IServices
{
    public interface IServices<T> where T : class
    {
        T read(int id);
        T read(string name);
        bool create(T entity);
        bool update(T entity);
        bool delete(T entity);
    }
}
