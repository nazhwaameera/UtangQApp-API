using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UtangQApp_Domain.Reports;
using UtangQApp_Domain.Transactions;
using UtangQApp_Domain.Users;

namespace UtangQApp_Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillPaymentReport> BillPaymentReports { get; set; }

    public virtual DbSet<BillRecipient> BillRecipients { get; set; }

    public DbSet<BillRecipientWithDesc> BillRecipientWithDesc { get; set; }

    public virtual DbSet<BillRecipientStatusReport> BillRecipientStatusReports { get; set; }

    public virtual DbSet<BillStatus> BillStatuses { get; set; }

    public virtual DbSet<Friendship> Friendships { get; set; }

    public virtual DbSet<FriendshipList> FriendshipLists { get; set; }

    public virtual DbSet<FriendshipStatus> FriendshipStatuses { get; set; }

    public virtual DbSet<PaymentReceipt> PaymentReceipts { get; set; }

    public virtual DbSet<PaymentReceiptReport> PaymentReceiptReports { get; set; }

    public virtual DbSet<TaxStatus> TaxStatuses { get; set; }

    public virtual DbSet<TransactionHistoryReport> TransactionHistoryReports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    public virtual DbSet<WalletBalanceReport> WalletBalanceReports { get; set; }

    public virtual DbSet<WalletTransaction> WalletTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\BSISqlExpress;Initial Catalog=UtangQ;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK_Bills_BillID");

            entity.HasOne(d => d.User).WithMany(p => p.Bills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bills__BillDescr__398D8EEE");
        });

        modelBuilder.Entity<BillPaymentReport>().HasNoKey().ToView("BillPaymentReport");

        modelBuilder.Entity<BillRecipient>(entity =>
        {
            entity.HasKey(e => e.BillRecipientId).HasName("PK_BillRecipients_BillRecipientID");

            entity.HasOne(d => d.BillRecipientStatus).WithMany(p => p.BillRecipients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillRecip__BillsStatus__4316F928");

            entity.HasOne(d => d.BillRecipientTaxStatus).WithMany(p => p.BillRecipients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillRecipTax__TaxStatus__412EB0B6");

            entity.HasOne(d => d.RecipientUser).WithMany(p => p.BillRecipients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillRecip__Recip__4222D4EF");
        });

        modelBuilder.Entity<BillRecipientWithDesc>().HasKey(b => b.BillRecipientID);

        modelBuilder.Entity<BillRecipientStatusReport>().HasNoKey().ToView("BillRecipientStatusReport");

        modelBuilder.Entity<BillStatus>(entity =>
        {
            entity.HasKey(e => e.BillStatusId).HasName("PK_BillStatus_BillStatusID");
        });

        modelBuilder.Entity<Friendship>(entity =>
        {
            entity.HasKey(e => e.FriendshipId).HasName("PK_Friendship_FriendshipID");

            entity.HasOne(d => d.User).WithMany(p => p.Friendships).HasConstraintName("FK_Friendship_UserID");
        });

        modelBuilder.Entity<FriendshipList>(entity =>
        {
            entity.HasKey(e => e.FriendshipListId).HasName("PK_FriendshipStatus_FriendshipStatusID");

            entity.HasOne(d => d.Friendship).WithMany(p => p.FriendshipLists).HasConstraintName("FK_FriendshipList_FriendshipListID");

            entity.HasOne(d => d.FriendshipStatus).WithMany(p => p.FriendshipLists).HasConstraintName("FK_FriendshipList_FriendshipStatusID");

            entity.HasOne(d => d.ReceiverUser).WithMany(p => p.FriendshipListReceiverUsers).HasConstraintName("FK_FriendshipList_ReceiverUserID");

            entity.HasOne(d => d.SenderUser).WithMany(p => p.FriendshipListSenderUsers).HasConstraintName("FK_FriendshipList_SenderUserID");
        });

        modelBuilder.Entity<FriendshipStatus>(entity =>
        {
            entity.HasKey(e => e.FriendshipStatusId).HasName("PK_FriendshipStatus_StatusID");
        });

        modelBuilder.Entity<PaymentReceipt>(entity =>
        {
            entity.HasKey(e => e.PaymentReceiptId).HasName("PK_PaymentReceipts_PaymentReceiptID");

            entity.Property(e => e.ConfirmationDate).HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            entity.HasOne(d => d.BillRecipient).WithMany(p => p.PaymentReceipts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PaymentRe__Payme__46E78A0C");
        });

        modelBuilder.Entity<PaymentReceiptReport>().HasNoKey().ToView("PaymentReceiptReport");

        modelBuilder.Entity<TaxStatus>(entity =>
        {
            entity.HasKey(e => e.TaxStatusId).HasName("PK_TaxStatus_TaxStatusID");
        });

        modelBuilder.Entity<TransactionHistoryReport>().HasNoKey().ToView("TransactionHistoryReport");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Users_UserID");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.WalletId).HasName("PK_Wallets_WalletID");

            entity.HasOne(d => d.User).WithMany(p => p.Wallets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wallets__WalletB__3C69FB99");
        });

        modelBuilder.Entity<WalletBalanceReport>().HasNoKey().ToView("WalletBalanceReport");

        modelBuilder.Entity<WalletTransaction>(entity =>
        {
            entity.HasKey(e => e.WalletTransactionId).HasName("PK_WalletTransactions_WalletTransactionID");

            entity.Property(e => e.TransactionDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Wallet).WithMany(p => p.WalletTransactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WalletTra__Trans__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
