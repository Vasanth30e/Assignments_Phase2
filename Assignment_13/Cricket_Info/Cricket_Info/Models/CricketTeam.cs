using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cricket_Info.Models
{
    [Table("CricketTeam")]
    public class CricketTeam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Team { get; set; }
        [Required]
        public int NOWC { get; set; }
    }
}