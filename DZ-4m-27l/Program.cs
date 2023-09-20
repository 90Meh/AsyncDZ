// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Start();

        async Task Start()

        {
            //Создание объекта подписка на события
            var imageDownloader = new ImageDownloader();
            imageDownloader.ImageStarted += Message.MessageStart;
            imageDownloader.ImageCompleted += Message.MessageEnd;


            //Вызов методов

            imageDownloader.Downloader();
            var task = imageDownloader.DownloaderAsync();



            //Конец выполнения
            Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
            examination(task);

            Console.ReadKey();


            Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
            Task task1 = null;
            for (int i = 0; i < 10; i++)
            {
                task1 = imageDownloader.DownloaderAsync();
            }
            examination(task1);
            Console.ReadKey();
        }

        

        static void examination(Task task)
        {
            var answer = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (answer != 65)
            {
                Console.WriteLine(task.IsCompletedSuccessfully);
                examination(task);
            }
        }
    }
}

public class ImageDownloader
{
    public int n = 1;
    //Имя файла
    private string fileName = "bigimage.jpg";
    private string fileNameA = "bigimageAsync.jpg";

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
        Console.WriteLine("Качаю Асинхронно\"{0}\" из \"{1}\" .......\n\n", fileNameA + n, remoteUri);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" Путь загрузки - {currentDir} \n \n");
        Console.ResetColor();
        ImageStarted();
        await myWebClient.DownloadFileTaskAsync(remoteUri, fileNameA + n);
        ImageCompleted();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Успешно скачал Асинхронно\"{0}\" из \"{1}\"", fileNameA + n, remoteUri);
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

//Класс для статуса загрузки
public static class Message
{

    public static void MessageStart() => Console.WriteLine("\n Скачивание файла началось \n");

    public static void MessageEnd() => Console.WriteLine("\n Скачивание файла закончилось \n");
}




//Делегаты
public delegate void EventStateDownload();
