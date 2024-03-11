using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.User;
using UtangQAppBLL.Interfaces.User;
using UtangQAppBO;
using UtangQAppDAL;
using UtangQAppDAL.Interfaces;

namespace UtangQAppBLL
{
    public class BillBLL : IBillBLL
    {
        private readonly IBill _billDAL;
        public BillBLL()
        {
            _billDAL = new BillDAL();
        }

        public void Create(BillCreateDTO entity)
        {
            try
            {
                var bill = new Bill
                {
                    UserID = entity.UserID,
                    BillAmount = entity.BillAmount,
                    BillDate = entity.BillDate,
                    BillDescription = entity.BillDescription,
                    OwnerContribution = entity.OwnerContribution
                };
                _billDAL.Create(bill);
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
                _billDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public BillDTO Get(int id)
        {
            BillDTO billDTO = new BillDTO();
            try
            {
                var bill = _billDAL.Get(id);
                billDTO.BillID = bill.BillID;
                billDTO.UserID = bill.UserID;
                billDTO.BillAmount = bill.BillAmount;
                billDTO.BillDate = bill.BillDate;
                billDTO.BillDescription = bill.BillDescription;
                billDTO.OwnerContribution = bill.OwnerContribution;
                return billDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<BillDTO> GetAll()
        {
            List<BillDTO> billDTOs = new List<BillDTO>();
            var billsDAL = _billDAL.GetAll();
            foreach(var bill in billsDAL)
            {
                BillDTO billDTO = new BillDTO
                {
                    BillID = bill.BillID,
                    UserID = bill.UserID,
                    BillAmount = bill.BillAmount,
                    BillDate = bill.BillDate,
                    BillDescription = bill.BillDescription,
                    OwnerContribution = bill.OwnerContribution
                };
                billDTOs.Add(billDTO);
            }
            return billDTOs;
        }

        public decimal GetTotalBillAmountCreatedPaidProcedure(int UserId)
        {
            try
            {
                decimal result = _billDAL.GetTotalBillAmountCreatedPaidProcedure(UserId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetTotalBillAmountCreatedPendingProcedure(int UserId)
        {
            try
            {
                decimal result = _billDAL.GetTotalBillAmountCreatedPendingProcedure(UserId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetTotalBillAmountCreatedProcedure(int UserId)
        {
            try
            {
                decimal result = _billDAL.GetTotalBillAmountCreatedProcedure(UserId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal CalculateTotalUnassignedBillAmount(int UserId)
        {
            try
            {
                decimal result = _billDAL.CalculateTotalUnassignedBillAmount(UserId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<BillDTO> ReadUserBills(int UserId)
        {
            List<BillDTO> bills = new List<BillDTO>();
            var billsDAL = _billDAL.ReadUserBills(UserId);
            foreach(Bill bill in billsDAL)
            {
                BillDTO billDTO = new BillDTO
                {
                    BillID = bill.BillID,
                    UserID = bill.UserID,
                    BillAmount = bill.BillAmount,
                    BillDate = bill.BillDate,
                    BillDescription = bill.BillDescription,
                    OwnerContribution = bill.OwnerContribution
                };
                bills.Add(billDTO);
            }
            return bills;
        }

        public void Update(BillDTO entity)
        {
            try
            {
                var bill = new Bill
                {
                    BillID = entity.BillID,
                    UserID = entity.UserID,
                    BillAmount = entity.BillAmount,
                    BillDate = entity.BillDate,
                    BillDescription = entity.BillDescription,
                    OwnerContribution = entity.OwnerContribution
                };
                _billDAL.Update(bill);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetTotalPendingAmountOwedProcedure(int RecipientUserID)
        {
            try
            {
                decimal result = _billDAL.GetTotalPendingAmountOwedProcedure(RecipientUserID);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetTotalBillAmountPaidProcedure(int RecipientUserID)
        {
            try
            {
                decimal result = _billDAL.GetTotalBillAmountPaidProcedure(RecipientUserID);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
