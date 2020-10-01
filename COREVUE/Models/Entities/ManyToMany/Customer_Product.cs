﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace COREVUE.Models.Entities.ManyToMany
{
    public class Customer_Product
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [JsonIgnore, IgnoreDataMember]
        public Customer Customer { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [JsonIgnore, IgnoreDataMember]
        public Product Product { get; set; }
    }
}
