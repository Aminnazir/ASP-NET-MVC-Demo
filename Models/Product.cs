using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AspMVCDemo.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
