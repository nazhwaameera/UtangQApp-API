using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Reports;
public partial class BillPaymentReport
{
    [Column(TypeName = "money")]
    public decimal BillAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BillDate { get; set; }

    [StringLength(100)]
    public string? BillDescription { get; set; }

    [StringLength(20)]
    public string PaymentStatus { get; set; } = null!;
}
