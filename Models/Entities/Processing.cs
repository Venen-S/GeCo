using Models.BaseEntity;

namespace Models.Entities
{
    public class Processing:Base<int>
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public string Status { get; set; }
    }
}