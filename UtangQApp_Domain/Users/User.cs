using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtangQApp_Domain.Transactions;

namespace UtangQApp_Domain.Users;

[Table("Users", Schema = "Users")]
public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string Username { get; set; } = null!;

    [StringLength(50)]
    public string UserPassword { get; set; } = null!;

    [StringLength(50)]
    public string UserEmail { get; set; } = null!;

    [StringLength(100)]
    public string? UserFullName { get; set; }

    [StringLength(20)]
    public string? UserPhoneNumber { get; set; }

    public bool IsLocked { get; set; }

    [InverseProperty("RecipientUser")]
    public virtual ICollection<BillRecipient> BillRecipients { get; set; } = new List<BillRecipient>();

    [InverseProperty("User")]
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    [InverseProperty("ReceiverUser")]
    public virtual ICollection<FriendshipList> FriendshipListReceiverUsers { get; set; } = new List<FriendshipList>();

    [InverseProperty("SenderUser")]
    public virtual ICollection<FriendshipList> FriendshipListSenderUsers { get; set; } = new List<FriendshipList>();

    [InverseProperty("User")]
    public virtual ICollection<Friendship> Friendships { get; set; } = new List<Friendship>();

    [InverseProperty("User")]
    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}
