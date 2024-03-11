using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.Interfaces.Transaction;
using UtangQAppBO;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;
using static Dapper.SqlMapper;

namespace UtangQAppBLL
{
    public class PaymentReceiptBLL : IPaymentReceiptBLL
    {
        private readonly IPaymentReceipt _paymentReceiptDAL;

        public PaymentReceiptBLL()
        {
            _paymentReceiptDAL = new PaymentReceiptDAL();
        }
        public void Create(PaymentReceiptCreateDTO entity)
        {
            throw new NotImplementedException();
        }

        public void CreatePaymentReceiptAndUpdateStatus(int BillRecipientID, string PaymentReceiptURL)
        {
            try
            {
                _paymentReceiptDAL.CreatePaymentReceiptAndUpdateStatus(BillRecipientID, PaymentReceiptURL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _paymentReceiptDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PaymentReceiptDTO Get(int id)
        {
            PaymentReceiptDTO paymentReceiptDTO = new PaymentReceiptDTO();
            try
            {
                var paymentReceipt = _paymentReceiptDAL.Get(id);
                paymentReceiptDTO.PaymentReceiptID = paymentReceipt.PaymentReceiptID;
                paymentReceiptDTO.BillRecipientID = paymentReceipt.BillRecipientID;
                paymentReceiptDTO.SentDate = paymentReceipt.SentDate;
                paymentReceiptDTO.ConfirmationDate = paymentReceipt.ConfirmationDate;
                paymentReceiptDTO.PaymentReceiptURL = paymentReceipt.PaymentReceiptURL;
                return paymentReceiptDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PaymentReceiptDTO> GetAll()
        {
            List<PaymentReceiptDTO> paymentReceiptDTOs = new List<PaymentReceiptDTO>();
            var paymentReceiptsDAL = _paymentReceiptDAL.GetAll();
            foreach (var paymentReceipts in paymentReceiptsDAL)
            {
                PaymentReceiptDTO paymentReceiptDTO = new PaymentReceiptDTO
                {
                    PaymentReceiptID = paymentReceipts.PaymentReceiptID,
                    BillRecipientID = paymentReceipts.BillRecipientID,
                    SentDate = paymentReceipts.SentDate,
                    ConfirmationDate = paymentReceipts.ConfirmationDate,
                    PaymentReceiptURL = paymentReceipts.PaymentReceiptURL
                };
                paymentReceiptDTOs.Add(paymentReceiptDTO);
            }
            return paymentReceiptDTOs;
        }

        public PaymentReceiptDTO ReadPaymentReceiptbyBillRecipientID(int BillRecipientID)
        {
            PaymentReceiptDTO paymentReceiptDTO = new PaymentReceiptDTO();
            try
            {
                var paymentReceipt = _paymentReceiptDAL.ReadPaymentReceiptbyBillRecipientID(BillRecipientID);
                paymentReceiptDTO.PaymentReceiptID = paymentReceipt.PaymentReceiptID;
                paymentReceiptDTO.BillRecipientID = paymentReceipt.BillRecipientID;
                paymentReceiptDTO.SentDate = paymentReceipt.SentDate;
                paymentReceiptDTO.ConfirmationDate = paymentReceipt.ConfirmationDate;
                paymentReceiptDTO.PaymentReceiptURL = paymentReceipt.PaymentReceiptURL;
                return paymentReceiptDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<PaymentReceiptDTO> ReadPaymentReceiptsByBillCreator(int CreatorUserID)
        {
            List<PaymentReceiptDTO> paymentReceiptDTOs = new List<PaymentReceiptDTO>();
            var paymentReceiptsDAL = _paymentReceiptDAL.ReadPaymentReceiptsByBillCreator(CreatorUserID);
            foreach (var paymentReceipts in paymentReceiptsDAL)
            {
                PaymentReceiptDTO paymentReceiptDTO = new PaymentReceiptDTO
                {
                    PaymentReceiptID = paymentReceipts.PaymentReceiptID,
                    BillRecipientID = paymentReceipts.BillRecipientID,
                    SentDate = paymentReceipts.SentDate,
                    ConfirmationDate = paymentReceipts.ConfirmationDate,
                    PaymentReceiptURL = paymentReceipts.PaymentReceiptURL
                };
                paymentReceiptDTOs.Add(paymentReceiptDTO);
            }
            return paymentReceiptDTOs;
        }

        public void Update(PaymentReceiptDTO entity)
        {
            try
            {
                var paymentReceipt = new PaymentReceipt
                {
                    PaymentReceiptID = entity.PaymentReceiptID,
                    BillRecipientID = entity.BillRecipientID,
                    SentDate = entity.SentDate,
                    ConfirmationDate = entity.ConfirmationDate,
                    PaymentReceiptURL = entity.PaymentReceiptURL
                };
                _paymentReceiptDAL.Update(paymentReceipt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateBillRecipientPaymentStatus(int BillRecipientID, int NewStatusID)
        {
            try
            {
                _paymentReceiptDAL.UpdateBillRecipientPaymentStatus(BillRecipientID, NewStatusID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
