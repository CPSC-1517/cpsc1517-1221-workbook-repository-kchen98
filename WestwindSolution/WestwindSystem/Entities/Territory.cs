using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestwindSystem.Entities
{
    public partial class Territory
    {
        [Key]
        [Column("TerritoryID")]
        [StringLength(20)]
        public string TerritoryId { get; set; } = null!;

        [StringLength(50)]
        public string TerritoryDescription { get; set; } = null!;

        [Column("RegionID")]
        public int RegionId { get; set; }

        [ForeignKey("RegionId")]
        [InverseProperty("Territories")]
        public virtual Region Region { get; set; } = null!;
    }
}
