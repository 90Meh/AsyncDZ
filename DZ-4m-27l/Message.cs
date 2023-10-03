using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4m_27l
{
    internal class Message
    {
        //Класс для статуса загрузки
        public static void MessageStart() => Console.WriteLine("\n Скачивание файла началось \n");

        public static void MessageEnd() => Console.WriteLine("\n Скачивание файла закончилось \n");
    }
}
