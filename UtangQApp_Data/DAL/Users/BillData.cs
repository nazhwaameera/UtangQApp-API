using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using UtangQApp_Data.Interfaces.Users;
using UtangQApp_Domain.Users;


namespace UtangQApp_Data.DAL.Users;

public class BillData : IBill
{
    private readonly AppDbContext _context;
    public BillData(AppDbContext context)
    {
        _context = context;
    }

    public async Task<decimal> CalculateTotalUnassignedBillAmount(int UserId)
    {
        var totalUnassignedBillAmount = await (
               from b in _context.Bills
               join br in _context.BillRecipients on b.BillId equals br.BillId into gj
               where gj.All(x => x.BillRecipientId == null) && b.UserId == UserId
               select b.BillAmount
           ).SumAsync();

        return totalUnassignedBillAmount;
    }


    public async Task<bool> Create(Bill entity)
    {
        try
        {
            _context.Bills.Add(entity);
            await _context.SaveChangesAsync();
            return true; // Return true if the operation is successful
        }
        catch (DbUpdateException ex)
        {
            // Handle any database-related exceptions
            Console.WriteLine("Insert data failed: " + ex.InnerException?.Message);
            return false; // Return false if the operation fails
        }
        catch (Exception ex)
        {
            // Handle any other exceptions
            Console.WriteLine("Insert data failed: " + ex.Message);
            return false; // Return false if the operation fails
        }
    }

    public async Task<bool> Delete(int id)
    {
        var bill = await _context.Bills.FindAsync(id);
        if (bill == null)
        {
            throw new ArgumentException("Bill not found");
        }

        _context.Bills.Remove(bill);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Bill> Get(int id)
    {
        try
        {
            return await _context.Bills.SingleOrDefaultAsync(b => b.BillId == id);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public async Task<IEnumerable<Bill>> GetAll()
    {
        return await _context.Bills.ToListAsync();
    }

    public async Task<decimal> GetTotalBillAmountAcceptedProcedure(int RecipientUserID)
    {
        var totalAmount = await (
            from br in _context.BillRecipients
            join bs in _context.BillStatuses on br.BillRecipientStatusId equals bs.BillStatusId
            where br.RecipientUserId == RecipientUserID && bs.BillStatusDescription == "Accepted"
            select br.BillRecipientAmount
        ).SumAsync();

        return totalAmount;
    }

    public async Task<decimal> GetTotalBillAmountAwaitingProcedure(int RecipientUserID)
    {
        var totalAmount = await (
            from br in _context.BillRecipients
            join bs in _context.BillStatuses on br.BillRecipientStatusId equals bs.BillStatusId
            where br.RecipientUserId == RecipientUserID && bs.BillStatusDescription == "Awaiting"
            select br.BillRecipientAmount
        ).SumAsync();

        return totalAmount;
    }

    public async Task<decimal> GetTotalBillAmountCreatedAcceptedProcedure(int UserId)
    {
        var totalAmount = await (
            from b in _context.Bills
            join br in _context.BillRecipients on b.BillId equals br.BillId
            join bs in _context.BillStatuses on br.BillRecipientStatusId equals bs.BillStatusId
            where b.UserId == UserId && bs.BillStatusDescription == "Accepted"
            select br.BillRecipientAmount
        ).SumAsync();

        return totalAmount;
    }

    public async Task<decimal> GetTotalBillAmountCreatedAwaitingProcedure(int UserId)
    {
        var totalAmount = await (
            from b in _context.Bills
            join br in _context.BillRecipients on b.BillId equals br.BillId
            join bs in _context.BillStatuses on br.BillRecipientStatusId equals bs.BillStatusId
            where b.UserId == UserId && bs.BillStatusDescription == "Awaiting"
            select br.BillRecipientAmount
        ).SumAsync();

        return totalAmount;
    }

    public async Task<decimal> GetTotalBillAmountCreatedPaidProcedure(int UserId)
    {
        var totalAmount = await (
            from b in _context.Bills
            join br in _context.BillRecipients on b.BillId equals br.BillId
            join bs in _context.BillStatuses on br.BillRecipientStatusId equals bs.BillStatusId
            where b.UserId == UserId && bs.BillStatusDescription == "Paid"
            select br.BillRecipientAmount
        ).SumAsync();

        return totalAmount;
    }

    public async Task<decimal> GetTotalBillAmountCreatedPendingProcedure(int UserId)
    {
        var totalAmount = await (
            from b in _context.Bills
            join br in _context.BillRecipients on b.BillId equals br.BillId
            join bs in _context.BillStatuses on br.BillRecipientStatusId equals bs.BillStatusId
            where b.UserId == UserId && bs.BillStatusDescription == "Pending"
            select br.BillRecipientAmount
        ).SumAsync();

        return totalAmount;
    }

    public async Task<decimal> GetTotalBillAmountCreatedProcedure(int UserId)
    {
        var totalAmount = await (
            from b in _context.Bills
            where b.UserId == UserId
            select b.BillAmount
        ).SumAsync();

        return totalAmount;
    }

    public async Task<decimal> GetTotalBillAmountCreatedRejectedProcedure(int UserId)
    {
        var totalAmount = await (
            from b in _context.Bills
            join br in _context.BillRecipients on b.BillId equals br.BillId
            join bs in _context.BillStatuses on br.BillRecipientStatusId equals bs.BillStatusId
            where b.UserId == UserId && bs.BillStatusDescription == "Rejected"
            select br.BillRecipientAmount
        ).SumAsync();

        return totalAmount;
    }

    public async Task<decimal> GetTotalBillAmountPaidProcedure(int RecipientUserID)
    {
        var totalAmount = await (
            from br in _context.BillRecipients
            join bs in _context.BillStatuses on br.BillRecipientStatusId equals bs.BillStatusId
            where br.RecipientUserId == RecipientUserID && bs.BillStatusDescription == "Paid"
            select br.BillRecipientAmount
        ).SumAsync();

        return totalAmount;
    }

    public async Task<decimal> GetTotalPendingAmountOwedProcedure(int RecipientUserID)
    {
        var totalAmount = await (
            from br in _context.BillRecipients
            join bs in _context.BillStatuses on br.BillRecipientStatusId equals bs.BillStatusId
            where br.RecipientUserId == RecipientUserID && bs.BillStatusDescription == "Pending"
            select br.BillRecipientAmount
        ).SumAsync();

        return totalAmount;
    }

    public async Task<IEnumerable<Bill>> ReadUserBills(int UserId)
    {
        try
        {
            return await _context.Bills.FromSqlRaw("EXEC Users.ReadUserBills @p0", UserId).ToListAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> Update(Bill entity)
    {
        try
        {
            // Retrieve the entity from the database
            var existingBill = await _context.Bills.SingleOrDefaultAsync(b => b.BillId == entity.BillId);
            if (existingBill == null)
            {
                throw new ArgumentException("Bill not found");
            }

            // Update the properties of the retrieved entity
            existingBill.UserId = entity.UserId;
            existingBill.BillAmount = entity.BillAmount;
            existingBill.BillDate = entity.BillDate;
            existingBill.BillDescription = entity.BillDescription;
            existingBill.OwnerContribution = entity.OwnerContribution;

            // Save the changes to the database
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException ex)
        {
            // Handle any database-related exceptions
            throw new ArgumentException("Update data failed: " + ex.InnerException?.Message);
        }
        catch (Exception ex)
        {
            // Handle any other exceptions
            throw new ArgumentException("Update data failed: " + ex.Message);
        }
    }
}
