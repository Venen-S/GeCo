using System;
using System.Text.Json;
using System.Threading;
using Data;

namespace Application
{
    public class Process
    {
        private IApiContext _context;
        public Process(IApiContext context)
        {
            _context = context;
        }


        public string TalabatHandlerMethod(string json)
        {
            var deserialize = WorkJson.DeserializeOrder(json);
            foreach (var product in deserialize.Products)
            {
                //конвертируем в инт, меняем знак, переводим снова в строку

                //На случай придирчивости. Ошибки тут нет. Положительное число мы меняем на отрицательное
                //А если исходное число отрицательное то поменяв отрицательное число на положительное
                //Оно не станет положительным, оно будет отрицательным числом для отрицательного числа, т.к.
                //уровню школьного курса математики известно что минус на минус дает плюс.
                //Но если вдруг и такой ответ не устраивает то тогда пусть будет вот так:
                //Если product.PaidPrice начинается (StartWith) со знака "-" то пропускаем итерацию и переходим к новой,
                //таким образом число остается отрицательным.
                //Надеюсь настолько тривиальная задача не требует расписания кодом
                product.PaidPrice = (-Int32.Parse(product.PaidPrice)).ToString();
            }

            var newJson = WorkJson.SerializeOrder(deserialize);
            return newJson;
        }

        public string ZomatoHandlerMethod(string json)
        {
            var deserialize = WorkJson.DeserializeOrder(json);
            foreach (var product in deserialize.Products)
            {
                //если я правильно понял задачу, то в каждом элементе списка products надо
                //поделить цены на количество позиций а не как то иначе
                //если так, то сорян, не очень понятна часть этой задачи
                //если что то можно и переделать, труда не составит
                product.PaidPrice = (decimal.Parse(product.PaidPrice) / decimal.Parse(product.Quantity)).ToString();
            }

            var newJson = WorkJson.SerializeOrder(deserialize);
            return newJson;
        }

        public string UberHandlerMethod(string json)
        {
            try
            {
                throw new JsonException("Упс, ошибочка вышла в uber");
            }
            catch (Exception ex)
            {
                new Thread(async () => await
                    ErrorService.AlarmaAhtungWarningErrorMethodAsync($"{ex.Message}")).Start();
                //Будем считать что обработка прошла успешно и возвращаем
                //исходный json который будет сохранен в столбце как обработанный
                //Ибо, раз обработка этого типа заказа заключается в выбрасывании исключения,
                //значит можно считать что она проделана
                return json;
            }
        }
    }
}