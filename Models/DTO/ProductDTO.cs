using System.Text.Json.Serialization;

namespace Models.DTO
{
    public class ProductDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }

        [JsonPropertyName("paidPrice")]
        public string PaidPrice { get; set; }

        [JsonPropertyName("unitPrice")]
        public string UnitPrice { get; set; }

        [JsonPropertyName("remoteCode")]
        public string RemoteCode { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("vatPercentage")]
        public string VatPercentage { get; set; }

        [JsonPropertyName("discountAmount")]
        public string DiscountAmount { get; set; }
    }
}