using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtangQApp_Domain.Users;

namespace UtangQApp_Domain.Transactions;

[Table("BillRecipients", Schema = "Transactions")]
public partial class BillRecipient
{
    [Key]
    [Column("BillRecipientID")]
    public int BillRecipientId { get; set; }

    [Column("BillID")]
    public int BillId { get; set; }

    [Column("RecipientUserID")]
    public int RecipientUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SentDate { get; set; }

    [Column("BillRecipientStatusID")]
    public int BillRecipientStatusId { get; set; }

    [Column("BillRecipientTaxStatusID")]
    public int BillRecipientTaxStatusId { get; set; }

    [Column(TypeName = "money")]
    public decimal BillRecipientAmount { get; set; }

    [ForeignKey("BillRecipientStatusId")]
    [InverseProperty("BillRecipients")]
    public virtual BillStatus BillRecipientStatus { get; set; } = null!;

    [ForeignKey("BillRecipientTaxStatusId")]
    [InverseProperty("BillRecipients")]
    public virtual TaxStatus BillRecipientTaxStatus { get; set; } = null!;

    [InverseProperty("BillRecipient")]
    public virtual ICollection<PaymentReceipt> PaymentReceipts { get; set; } = new List<PaymentReceipt>();

    [ForeignKey("RecipientUserId")]
    [InverseProperty("BillRecipients")]
    public virtual User RecipientUser { get; set; } = null!;
}
