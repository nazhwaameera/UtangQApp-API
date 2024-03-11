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
    public class BillRecipientBLL : IBillRecipientBLL
    {
        private readonly IBillRecipient _billRecipientDAL;

        public BillRecipientBLL()
        {
            _billRecipientDAL = new BillRecipientDAL();
        }
        public void Create(BillRecipientCreateDTO entity)
        {
            try
            {
                var billRecipient = new BillRecipientCreate
                {
                    BillID = entity.BillID,
                    RecipientUserID = entity.RecipientUserID,
                    TotalUsers = entity.TotalUsers,
                    IsSplitEvenly = entity.IsSplitEvenly,
                    TaxStatusDescription = entity.TaxStatusDescription,
                    TaxCharged = entity.TaxCharged
                };
                _billRecipientDAL.Create(billRecipient);
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
                _billRecipientDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BillRecipientDTO Get(int id)
        {
            BillRecipientDTO billRecipientDTO = new BillRecipientDTO();
            try
            {
                var billRecipient = _billRecipientDAL.Get(id);
                billRecipientDTO.BillRecipientID = billRecipient.BillRecipientID;
                billRecipientDTO.BillID = billRecipient.BillID;
                billRecipientDTO.RecipientUserID = billRecipient.RecipientUserID;
                billRecipientDTO.SentDate = billRecipient.SentDate;
                billRecipientDTO.BillRecipientStatusID = billRecipient.BillRecipientStatusID;
                billRecipientDTO.BillRecipientTaxStatusID = billRecipient.BillRecipientTaxStatusID;
                billRecipientDTO.BillRecipientAmount = billRecipient.BillRecipientAmount;
                return billRecipientDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<BillRecipientDTO> GetAll()
        {
            List<BillRecipientDTO> billRecipientDTOs = new List<BillRecipientDTO>();
            var billRecipientsDAL = _billRecipientDAL.GetAll();
            foreach (var billRecipients in billRecipientsDAL)
            {
                BillRecipientDTO billRecipientDTO = new BillRecipientDTO
                {
                    BillRecipientID = billRecipients.BillRecipientID,
                    BillID = billRecipients.BillID,
                    RecipientUserID = billRecipients.RecipientUserID,
                    SentDate = billRecipients.SentDate,
                    BillRecipientStatusID = billRecipients.BillRecipientStatusID,
                    BillRecipientTaxStatusID = billRecipients.BillRecipientTaxStatusID,
                    BillRecipientAmount = billRecipients.BillRecipientAmount
                };
                billRecipientDTOs.Add(billRecipientDTO);
            }
            return billRecipientDTOs;
        }

        public IEnumerable<BillRecipientDTO> GetBillRecipientsByBillID(int BillID)
        {
            List<BillRecipientDTO> billRecipientDTOs = new List<BillRecipientDTO>();
            var billRecipients = _billRecipientDAL.GetBillRecipientsByBillID(BillID);
            foreach (var billRecipient in billRecipients)
            {
                BillRecipientDTO billRecipientDTO = new BillRecipientDTO
                {
                    BillRecipientID = billRecipient.BillRecipientID,
                    BillID = billRecipient.BillID,
                    RecipientUserID = billRecipient.RecipientUserID,
                    SentDate = billRecipient.SentDate,
                    BillRecipientStatusID = billRecipient.BillRecipientStatusID,
                    BillRecipientTaxStatusID = billRecipient.BillRecipientTaxStatusID,
                    BillRecipientAmount = billRecipient.BillRecipientAmount
                };
                billRecipientDTOs.Add(billRecipientDTO);
            }
            return billRecipientDTOs;
        }

        public IEnumerable<BillRecipientDTO> ReadBillRecipientByRecipientUserID(int RecipientUserID)
        {
            List<BillRecipientDTO> billRecipientDTOs = new List<BillRecipientDTO>();
            var billRecipients = _billRecipientDAL.ReadBillRecipientByRecipientUserID(RecipientUserID);
            foreach (var billRecipient in billRecipients)
            {
                BillRecipientDTO billRecipientDTO = new BillRecipientDTO
                {
                    BillRecipientID = billRecipient.BillRecipientID,
                    BillID = billRecipient.BillID,
                    RecipientUserID = billRecipient.RecipientUserID,
                    SentDate = billRecipient.SentDate,
                    BillRecipientStatusID = billRecipient.BillRecipientStatusID,
                    BillRecipientTaxStatusID = billRecipient.BillRecipientTaxStatusID,
                    BillRecipientAmount = billRecipient.BillRecipientAmount
                };
                billRecipientDTOs.Add(billRecipientDTO);
            }
            return billRecipientDTOs;
        }

        public void Update(BillRecipientDTO entity)
        {
            try
            {
                var billRecipient = new BillRecipient
                {
                    BillRecipientID = entity.BillRecipientID,
                    BillID = entity.BillID,
                    RecipientUserID = entity.RecipientUserID,
                    SentDate = entity.SentDate,
                    BillRecipientStatusID = entity.BillRecipientStatusID,
                    BillRecipientTaxStatusID = entity.BillRecipientTaxStatusID,
                    BillRecipientAmount = entity.BillRecipientAmount
                };
                _billRecipientDAL.Update(billRecipient);
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
                _billRecipientDAL.UpdateBillRecipientPaymentStatus(BillRecipientID, NewStatusID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
