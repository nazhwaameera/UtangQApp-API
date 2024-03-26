using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtangQApp_Domain.Users;

namespace UtangQApp_Domain.Transactions;

[Table("WalletTransactions", Schema = "Transactions")]
public partial class WalletTransaction
{
    [Key]
    [Column("WalletTransactionID")]
    public int WalletTransactionId { get; set; }

    [Column("WalletID")]
    public int WalletId { get; set; }

    [Column(TypeName = "money")]
    public decimal WalletTransactionAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }

    public string? TransactionDescription { get; set; }

    [ForeignKey("WalletId")]
    [InverseProperty("WalletTransactions")]
    public virtual Wallet Wallet { get; set; } = null!;
}
