using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Data;
using Models.DTO;
using Models.Entities;
using Application;
using Models.Enums;

namespace GeCo.Controllers
{
    [ApiController]
    [Route("api/")]
    public class FoodController : ControllerBase
    {
        private IApiContext _context;

        public FoodController(IApiContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("order/{system}")]
        public async Task Order(string system, object order)
        {
            //Десериализуем запрос
            var deOrder = WorkJson.DeserializeOrder(order);

            //Добавляем запись
            Order orderDb = new Order
            {
                SystemType = system,
                OrderNumber = Int64.Parse(deOrder.OrderNumber),
                SourceOrder = order.ToString(),
                CreatedAt = deOrder.CreatedAt
            };
            _context.Orders.Add(orderDb);
            //Сохраняем
            await _context.SaveChangesAsync();

            //Берем идшник
            var id = orderDb.Id;
            ////Создаем запись о новом заказе
            ////З.Ы. Более целесообразно статусы было бы запихнуть в таблицу Ордер, но
            ////я так понимаю что таблица должна быть именно такой как в тз,
            ////поэтому статусы к ней запихнул отдельно
            _context.Processings.Add(new Processing
            {
                OrderId = id,
                Status = StatusOrder.New
            });
            await _context.SaveChangesAsync();
        }
    }
}
