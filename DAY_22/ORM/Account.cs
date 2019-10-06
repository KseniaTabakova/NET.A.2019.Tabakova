namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Account
    {
        [Key]
        [StringLength(50)]
        public string Number { get; set; }

        public int OwnerId { get; set; }

        public decimal Balance { get; set; }

        public int BonusPoints { get; set; }

        public int AccountTypeId { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        public virtual AccountOwner AccountOwner { get; set; }

        public virtual AccountType AccountType { get; set; }
    }
}
