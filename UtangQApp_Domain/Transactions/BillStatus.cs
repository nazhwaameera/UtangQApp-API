using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Transactions;

[Table("BillStatus", Schema = "Transactions")]
public partial class BillStatus
{
    [Key]
    [Column("BillStatusID")]
    public int BillStatusId { get; set; }

    [StringLength(20)]
    public string BillStatusDescription { get; set; } = null!;

    [InverseProperty("BillRecipientStatus")]
    public virtual ICollection<BillRecipient> BillRecipients { get; set; } = new List<BillRecipient>();
}
