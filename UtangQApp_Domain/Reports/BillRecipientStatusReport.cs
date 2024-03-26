using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Reports;
public partial class BillRecipientStatusReport
{
    [Column("BillRecipientID")]
    public int BillRecipientId { get; set; }

    [Column("BillID")]
    public int BillId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SentDate { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = null!;
}
