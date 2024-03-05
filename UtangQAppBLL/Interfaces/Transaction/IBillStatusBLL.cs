using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Transaction;

namespace UtangQAppBLL.Interfaces.Transaction
{
    public interface IBillStatusBLL : ICrudBLL<BillStatusDTO>
    {
        void Create(BillStatusCreateDTO entity); 
    }
}
