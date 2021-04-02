using Models.DTO;
using System.Text.Json;

namespace Application
{
    public  static class WorkJson
    {
        /// <summary>
        /// Десериализация JSON
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static OrderDto DeserializeOrder(object order)
        {
            var deserialize = JsonSerializer.Deserialize<OrderDto>((string)order.ToString());
            return deserialize;
        }

        public static string SerializeOrder(OrderDto order)
        {
            var serialize = JsonSerializer.Serialize(order);
            return serialize;
        }
    }
}