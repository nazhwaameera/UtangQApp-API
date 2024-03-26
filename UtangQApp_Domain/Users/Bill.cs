using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Users;

[Table("Bills", Schema = "Users")]
public partial class Bill
{
    [Key]
    [Column("BillID")]
    public int BillId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column(TypeName = "money")]
    public decimal BillAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BillDate { get; set; }

    [StringLength(100)]
    public string? BillDescription { get; set; }

    [Column(TypeName = "money")]
    public decimal OwnerContribution { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Bills")]
    public virtual User User { get; set; } = null!;
}
