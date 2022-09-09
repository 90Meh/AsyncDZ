// See https://aka.ms/new-console-template for more information

using System.Net;

Start();


async Task Start()

{
    //Создание объекта подписка на события
    var imageDownloader = new ImageDownloader();
    imageDownloader.ImageStarted += Message.MessageStart;
    imageDownloader.ImageCompleted += Message.MessageEnd;


    //Вызов методов

    var task = imageDownloader.DownloaderAsync();
    imageDownloader.Downloader();

    task.Wait();
    //Конец выполнения    
    Console.WriteLine("Нажмите любую клавишу для выхода.");
    Console.ReadKey();
}



public class ImageDownloader
{
    public int n = 1;
    //Имя файла
    private string fileName = "bigimage.jpg";
    private string fileNameA = "bigimageAsync.jpg";

    //Адрес картинки
    private string remoteUri = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
    //Путь к текущей директории
    private string currentDir = Directory.GetCurrentDirectory();


    //Асинхронный загрузчик фотографии
    public async Task DownloaderAsync()
    {
        var myWebClient = new WebClient();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Качаю Асинхронно\"{0}\" из \"{1}\" .......\n\n", fileNameA, remoteUri);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" Путь загрузки - {currentDir} \n \n");
        Console.ResetColor();
        ImageStarted();
        await myWebClient.DownloadFileTaskAsync(remoteUri, fileNameA);
        ImageCompleted();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Успешно скачал Асинхронно\"{0}\" из \"{1}\"", fileNameA, remoteUri);
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