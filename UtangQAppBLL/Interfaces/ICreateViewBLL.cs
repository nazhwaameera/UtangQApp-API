using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.Interfaces
{
    public interface ICreateViewBLL<T>
    {
        IEnumerable<T> CreateView(int UserId);
    }
}
