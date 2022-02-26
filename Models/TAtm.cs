using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TPS.Models
{
    [Table("t_ATM")]
    public partial class TAtm
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [Column("ATM_Name")]
        [StringLength(50)]
        public string AtmName { get; set; }
        [Column("ATM_Balance", TypeName = "decimal(18, 0)")]
        public decimal? AtmBalance { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedOn { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? ModifiedOn { get; set; }
    }
}
