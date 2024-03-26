using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Reports;

public partial class PaymentReceiptReport
{
    [Column("PaymentReceiptID")]
    public int PaymentReceiptId { get; set; }

    [Column("BillRecipientID")]
    public int BillRecipientId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReceiptSentDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmationDate { get; set; }

    [Column("PaymentReceiptURL")]
    public string PaymentReceiptUrl { get; set; } = null!;
}
