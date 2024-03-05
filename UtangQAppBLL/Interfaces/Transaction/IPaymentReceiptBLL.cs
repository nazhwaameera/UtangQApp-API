using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Transaction;

namespace UtangQAppBLL.Interfaces.Transaction
{
    public interface IPaymentReceiptBLL : ICrudBLL<PaymentReceiptDTO>
    {
        void Create(PaymentReceiptCreateDTO entity);
    }
}
