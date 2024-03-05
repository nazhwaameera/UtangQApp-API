using System;
using System.Collections.Generic;

namespace UtangQAppBO
{
    public class User
    {
        public User()
        {
            this.BillRecipients = new List<BillRecipient>();
            this.Bills = new List<Bill>();
            this.Wallet = new Wallet();
        }

        public int UserID { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserFullName { get; set; }
        public string UserPhoneNumber { get; set; }
        public bool IsLocked { get; set; }

        public List<BillRecipient> BillRecipients { get; set; }
        public List<Bill> Bills { get; set; }
        public Wallet Wallet { get; set; }

    }
}
