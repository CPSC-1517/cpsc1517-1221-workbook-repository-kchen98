using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestwindSystem.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("ProductID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "ProductName is required")]
        [MaxLength(40, ErrorMessage = "ProductName cannot contain more than 40 characters")]
        public string ProductName { get; set; } = null!;

        [Required(ErrorMessage = "SupplierID is required")]
        public int SupplierID { get; set; }

        public virtual Category? Category { get; set; }  

        [Required(ErrorMessage = "CategoryID is required")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "QuantityPerUnit is required")]
        [MaxLength(20, ErrorMessage = "QuantityPerUnit cannot contain more than 20 characters")]
        public string QuantityPerUnit { get; set; } = null!;

        public int? MinimumOrderQuantity { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "UnitPrice is required")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "UnitsOnOrder is required")]
        public int UnitsOnOrder { get; set; }

        [Required(ErrorMessage = "Discontinued is required")]
        public bool Discontinued { get; set; }
    }
}
