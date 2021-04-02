using System;
using Models.BaseEntity;

namespace Models.Entities
{
    public class Order:Base<long>
    {
        public string SystemType { get; set; }
        public long OrderNumber { get; set; }
        public string SourceOrder { get; set; }
        public string ConvertedOrder { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}