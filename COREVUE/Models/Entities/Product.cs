using COREVUE.Models.Entities.ManyToMany;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COREVUE.Models.Entities
{
    [JsonObject(IsReference = true)]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }

        public ICollection<Customer_Product> Customer_Products { get; set; }
    }
}
