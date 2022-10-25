using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestwindSystem.Entities
{
    [Table(name:"Categories")]
    public class Category
    {
        [Key]
        [Column(name:"CategoryID")]
        public int ID { get; set; }
        [Required(ErrorMessage = "CategoryName is required")]
        [MaxLength(15, ErrorMessage = "CategoryName cannot contain more than 15 characters")]
        public string CategoryName { get; set; } = string.Empty;
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
        [Column(TypeName = "varbinary")]
        public byte[]? Picture { get; set; }
        public string? PictureMimeType { get; set; }
    }
}
