using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.Transaction;
using UtangQAppBLL.Interfaces.Transaction;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;

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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BillRecipientDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BillRecipientDTO> GetAll()
        {
            throw new NotImplementedException();
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

        public void Update(BillRecipientDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
