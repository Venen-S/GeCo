using System.Text;
using Models.DTO;

namespace Application
{
    public static class WorkString
    {
        /// <summary>
        /// Конвертация модели в строку
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static string LineAfterConversion(OrderDto order)
        {
            //Изначально я не правильно понял задачу и думал что после
            //десериализации запроса 
            //надо конвертировать его в монолитную строку и записать
            //в колонке converted_order
            //только потом понял что ошибся
            //оставил на всякий случай, не удалять же такую красоту, жалко
            StringBuilder afterConv = new StringBuilder($"{nameof(order.OrderNumber)}: {order.OrderNumber} ");
            foreach (var dto in order.Products)
            {
                afterConv.Append($"{nameof(dto.Id)}: {dto.Id} " +
                                 $"{nameof(dto.Name)}: {dto.Name} " +
                                 $"{nameof(dto.Comment)}: {dto.Comment} " +
                                 $"{nameof(dto.Quantity)}: {dto.Quantity} " +
                                 $"{nameof(dto.PaidPrice)}: {dto.PaidPrice} " +
                                 $"{nameof(dto.UnitPrice)}: {dto.UnitPrice} " +
                                 $"{nameof(dto.RemoteCode)}: {dto.RemoteCode} " +
                                 $"{nameof(dto.Description)}: {dto.Description} " +
                                 $"{nameof(dto.VatPercentage)}: {dto.VatPercentage} " +
                                 $"{nameof(dto.DiscountAmount)}: {dto.DiscountAmount} ");
            }

            afterConv.Append($"{nameof(order.CreatedAt)}: {order.CreatedAt}");

            return afterConv.ToString();
        }
    }
}