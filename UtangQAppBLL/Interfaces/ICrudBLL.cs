using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.Interfaces
{
    public interface ICrudBLL<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T entity);
        void Delete(int id);
    }
}
