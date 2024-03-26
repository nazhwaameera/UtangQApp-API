using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Users;

[Table("FriendshipStatus", Schema = "Users")]
public partial class FriendshipStatus
{
    [Key]
    [Column("FriendshipStatusID")]
    public int FriendshipStatusId { get; set; }

    [StringLength(50)]
    public string FriendshipStatusDescription { get; set; } = null!;

    [InverseProperty("FriendshipStatus")]
    public virtual ICollection<FriendshipList> FriendshipLists { get; set; } = new List<FriendshipList>();
}
