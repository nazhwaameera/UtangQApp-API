using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppDAL.Interfaces
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
