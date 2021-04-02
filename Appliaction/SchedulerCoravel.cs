using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Coravel.Invocable;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Enums;

namespace Application
{
    public class SchedulerCoravel : IInvocable
    {
        private IApiContext _context;
        private IConfiguration _configuration;

        public SchedulerCoravel(IApiContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //Обработка новых заказов, самый фарш тут
        public async Task Invoke()
        {
            //Ищем новые заказы
            var status = _context.Processings
                .AsNoTracking()
                .Where(p => p.Status == "new")
                .ToList();
            if (status.Count>0)
            {
                //вытаскиваем словарь с системой и методом который должен быть вызван
                Process process = new Process(_context); 
                Type type = typeof(Process);
                var dictionary = _context.Choices
                    .AsNoTracking()
                    .ToDictionary(c => c.Key, c => c.Value);

                //Находим в таблице ордеров записи по вытащенным идшникам
                foreach (var processing in status)
                {
                    var item = _context.Orders.AsNoTracking().FirstOrDefault(o => o.Id == processing.OrderId);
                    //Для каждой итерации смотрим название метода в словаре по ключу
                    //через рефлексию находим метод и вызываем его для каждой системы собственный
                    var method = dictionary.FirstOrDefault(d => d.Key == item.SystemType);
                    MethodInfo info = type.GetMethod(method.Value);

                    try
                    {
                        //Вызываем найденный метод с json
                        var obj = info?.Invoke(process, new object[] {item.SourceOrder});
                        string json = (string) obj;

                        item.ConvertedOrder = json;
                        processing.Status = StatusOrder.Finish;
                        _context.Orders.Update(item);
                        _context.Processings.Update(processing);
                    }
                    catch (Exception ex)
                    {
                        //Делаем гарантированный запуск задачи в новом
                        //потоке чтобы не прерывал обработку заказов
                        //и передаем управление новой итерации
                        new Thread(async () => await 
                            ErrorService.AlarmaAhtungWarningErrorMethodAsync(ex.Message)).Start();
                        continue;
                    }
                }

                await _context.SaveChangesAsync();
            }
        }

    }
}