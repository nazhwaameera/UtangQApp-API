using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_Domain.Users;

[Table("Wallets", Schema = "Users")]
public partial class Wallet
{
    [Key]
    [Column("WalletID")]
    public int WalletId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column(TypeName = "money")]
    public decimal WalletBalance { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Wallets")]
    public virtual User User { get; set; } = null!;

    [InverseProperty("Wallet")]
    public virtual ICollection<WalletTransaction> WalletTransactions { get; set; } = new List<WalletTransaction>();
}
