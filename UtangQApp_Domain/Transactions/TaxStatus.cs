using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Transactions;

[Table("TaxStatus", Schema = "Transactions")]
public partial class TaxStatus
{
    [Key]
    [Column("TaxStatusID")]
    public int TaxStatusId { get; set; }

    [StringLength(20)]
    public string TaxStatusDescription { get; set; } = null!;

    [InverseProperty("BillRecipientTaxStatus")]
    public virtual ICollection<BillRecipient> BillRecipients { get; set; } = new List<BillRecipient>();
}
