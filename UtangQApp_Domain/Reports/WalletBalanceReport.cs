using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Reports;

public partial class WalletBalanceReport
{
    [Column("UserID")]
    public int UserId { get; set; }

    [Column(TypeName = "money")]
    public decimal WalletBalance { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }

    [Column(TypeName = "money")]
    public decimal WalletTransactionAmount { get; set; }

    public string? TransactionDescription { get; set; }
}
