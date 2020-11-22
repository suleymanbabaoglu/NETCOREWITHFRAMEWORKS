using Newtonsoft.Json;
using SAMPLE.Models.Entities.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SAMPLE.Models.Entities
{
    [JsonObject(IsReference = true)]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }

        [JsonIgnore, IgnoreDataMember]
        public ICollection<Customer_Product> Customer_Products { get; set; }
    }
}
