using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models.DTO
{
    public class OrderDto
    {
        [JsonPropertyName("orderNumber")]
        public string OrderNumber { get; set; }

        [JsonPropertyName("products")]
        public List<ProductDTO> Products { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}