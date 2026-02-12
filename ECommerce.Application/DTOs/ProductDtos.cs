using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class CreateProductDtos
    {
        [Required]
        public string Name {  get; set; }
        [Range(1, 100000)]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId {  get; set; }
    }
    public class ProductResponseDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,1000)]
        public decimal Price { get; set; }
    }
}
