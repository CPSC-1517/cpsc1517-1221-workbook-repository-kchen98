using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestwindSystem.Entities
{
    [Table(name:"Categories")]
    public class Category
    {
        [Key]
        [Column(name:"CategoryID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "CategoryName is required")]
        [MaxLength(15, ErrorMessage = "CategoryName cannot contain more than 15 characters")]
        public string CategoryName { get; set; } = null!;

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        [Column(TypeName = "varbinary")]
        public byte[]? Picture { get; set; }

        public string? PictureMimeType { get; set; }
    }
}
