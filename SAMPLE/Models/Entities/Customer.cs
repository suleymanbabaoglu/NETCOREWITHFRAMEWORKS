using SAMPLE.Models.Entities.ManyToMany;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAMPLE.Models.Entities
{
    [JsonObject(IsReference = true)]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<Customer_Product> Customer_Products { get; set; }
    }
}
