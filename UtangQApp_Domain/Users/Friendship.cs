using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Users;

[Table("Friendship", Schema = "Users")]
public partial class Friendship
{
    [Key]
    [Column("FriendshipID")]
    public int FriendshipId { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [InverseProperty("Friendship")]
    public virtual ICollection<FriendshipList> FriendshipLists { get; set; } = new List<FriendshipList>();

    [ForeignKey("UserId")]
    [InverseProperty("Friendships")]
    public virtual User? User { get; set; }
}
