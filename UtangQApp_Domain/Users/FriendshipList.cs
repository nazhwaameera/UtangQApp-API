using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtangQApp_Domain.Users;

[Table("FriendshipList", Schema = "Users")]
public partial class FriendshipList
{
    [Key]
    [Column("FriendshipListID")]
    public int FriendshipListId { get; set; }

    [Column("FriendshipID")]
    public int? FriendshipId { get; set; }

    [Column("SenderUserID")]
    public int? SenderUserId { get; set; }

    [Column("ReceiverUserID")]
    public int? ReceiverUserId { get; set; }

    [Column("FriendshipStatusID")]
    public int? FriendshipStatusId { get; set; }

    [ForeignKey("FriendshipId")]
    [InverseProperty("FriendshipLists")]
    public virtual Friendship? Friendship { get; set; }

    [ForeignKey("FriendshipStatusId")]
    [InverseProperty("FriendshipLists")]
    public virtual FriendshipStatus? FriendshipStatus { get; set; }

    [ForeignKey("ReceiverUserId")]
    [InverseProperty("FriendshipListReceiverUsers")]
    public virtual User? ReceiverUser { get; set; }

    [ForeignKey("SenderUserId")]
    [InverseProperty("FriendshipListSenderUsers")]
    public virtual User? SenderUser { get; set; }
}
