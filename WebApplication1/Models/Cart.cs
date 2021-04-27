using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double price { get; set; }

        public string ProductImage { get; set; }

        public int Quantity { get; set; }


    }
}
