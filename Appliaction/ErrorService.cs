using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public static class ErrorService
    {
        /// <summary>
        /// Обработчик ошибок
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static async Task AlarmaAhtungWarningErrorMethodAsync(string ex)
        {
            string writePath = "log.txt";
            //Паникуем, кричим и записываем в файл что все пропало и все сломалось, и нам всем PI...
            //с текстом ошибки
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                await sw.WriteLineAsync("Ошибка, алярма, ахтунг, ворнинг, " +
                                        "ерорр, еррор, армагедец, шеф все пропало, \n" +
                                        "все поломалось и сломалось *звуки запиканного " +
                                        "матерящегося R2D2 совместно со звуками \n" +
                                        "соединения старого модема к интернету*.\n" +
                                        $"Вот текст ошибoчки - {ex} \n");
                sw.Close();
            }
            //Дышим глубоко и считаем до 10
            //Повторяя себе "соберись тряпка" xD
            //и изображаем оооооочень бурную деятельность
            Thread.Sleep(10000);
        }
    }
}