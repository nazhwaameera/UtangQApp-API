using System;
using System.Collections.Generic;
using System.Text;
using UtangQAppBLL.DTOs.User;

namespace UtangQAppBLL.Interfaces.User
{
    public interface IBillBLL : ICrudBLL<BillDTO>
    {
        void Create(BillCreateDTO entity);
        IEnumerable<BillDTO> ReadUserBills(int UserId);
        decimal GetTotalBillAmountCreatedProcedure(int UserId);
        decimal CalculateTotalUnassignedBillAmount(int UserId);
        decimal GetTotalBillAmountCreatedPendingProcedure(int UserId);
        decimal GetTotalBillAmountCreatedPaidProcedure(int UserId);
		decimal GetTotalBillAmountCreatedAcceptedProcedure(int UserId);
		decimal GetTotalBillAmountCreatedRejectedProcedure(int UserId);
		decimal GetTotalBillAmountCreatedAwaitingProcedure(int UserId);
		decimal GetTotalPendingAmountOwedProcedure(int RecipientUserID);
        decimal GetTotalBillAmountPaidProcedure(int RecipientUserID);
		decimal GetTotalBillAmountAcceptedProcedure(int RecipientUserID);
		decimal GetTotalBillAmountAwaitingProcedure(int RecipientUserID);
	}
}
