using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Reports;

public partial class TransactionHistoryReport
{
    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }

    [Column(TypeName = "money")]
    public decimal TransactionAmount { get; set; }

    public string? TransactionDescription { get; set; }
}
