using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TPS.Models
{
    [Table("t_User_Accounts")]
    public partial class TUserAccount
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [Column("User_Id")]
        [StringLength(50)]
        public string UserId { get; set; }
        [Required]
        [Column("Acc_Name")]
        [StringLength(50)]
        public string AccName { get; set; }
        [Column("Acc_Balance", TypeName = "decimal(18, 0)")]
        public decimal AccBalance { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? CreatedOn { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? ModifiedOn { get; set; }
    }
}
