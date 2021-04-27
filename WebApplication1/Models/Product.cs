using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ProductImage { get; set; }

        public string FitFor { get; set; }

        public string Manufacturer { get; set; }

        public string Video { get; set; }



        public int Quantity { get; set; }
    }
}
