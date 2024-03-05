using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppDAL.Interfaces
{
    public interface ICreateView<T>
    {
        IEnumerable<T> CreateView(int UserId);
    }
}
