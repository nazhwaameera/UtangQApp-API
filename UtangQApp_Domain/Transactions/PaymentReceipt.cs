using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Transactions;

[Table("PaymentReceipts", Schema = "Transactions")]
public partial class PaymentReceipt
{
    [Key]
    [Column("PaymentReceiptID")]
    public int PaymentReceiptId { get; set; }

    [Column("BillRecipientID")]
    public int BillRecipientId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SentDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmationDate { get; set; }

    [Column("PaymentReceiptURL")]
    public string PaymentReceiptUrl { get; set; } = null!;

    [ForeignKey("BillRecipientId")]
    [InverseProperty("PaymentReceipts")]
    public virtual BillRecipient BillRecipient { get; set; } = null!;
}
