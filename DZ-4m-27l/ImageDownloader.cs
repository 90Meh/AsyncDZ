using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4m_27l
{
    internal class ImageDownloader
    {
        public int n = 1;
        //Имя файла
        private string fileName = "bigimage.jpg";
        private string fileNameA = "bigimageAsync";

        //Адрес картинки
        private string remoteUri = "http://www.wincore.ru/uploads/posts/2016-07/1467891335_rw-5.jpg";
        //Путь к текущей директории
        private string currentDir = Directory.GetCurrentDirectory();


        //Асинхронный загрузчик фотографии
        public async Task DownloaderAsync()
        {
            n++;
            var myWebClient = new WebClient();
            Console.ForegroundColor = ConsoleColor.Green;
            var name = (fileNameA + n + ".jpg");
            Console.WriteLine("Качаю Асинхронно\"{0}\" из \"{1}\" .......\n\n", name, remoteUri);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" Путь загрузки - {currentDir} \n \n");
            Console.ResetColor();
            ImageStarted();
            await myWebClient.DownloadFileTaskAsync(remoteUri, fileNameA + n + ".jpg");
            ImageCompleted();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Успешно скачал Асинхронно\"{0}\" из \"{1}\"", name, remoteUri);
            Console.ResetColor();
        }

        //Загрузчик для фотографии
        public void Downloader()
        {
            var myWebClient = new WebClient();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" Путь загрузки - {currentDir} \n \n");
            Console.ResetColor();
            ImageStarted();
            myWebClient.DownloadFile(remoteUri, fileName);
            ImageCompleted();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
            Console.ResetColor();
        }



        //События

        public event EventStateDownload ImageStarted;

        public event EventStateDownload ImageCompleted;
    }
}
