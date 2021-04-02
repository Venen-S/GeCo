using Models.BaseEntity;

namespace Models.Entities
{
    public class Choice:Base<int>
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}