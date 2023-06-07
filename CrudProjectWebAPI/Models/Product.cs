using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrudProjectWebAPI.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
