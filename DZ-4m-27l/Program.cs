// See https://aka.ms/new-console-template for more information

using DZ_4m_27l;
using System.Net;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Start(Examination);      
        
        Console.ReadKey();       
    }
    static void Examination(Task task)
    {
        var answer = Console.ReadKey().KeyChar;
        Console.WriteLine();
        if (answer != 65)
        {
            Console.WriteLine(task.IsCompletedSuccessfully);
            Examination(task);
        }
    }
    async static Task Start(StartExamDelegate Examination)

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
        Examination(task);

        Console.ReadKey();


        Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
        List<Task> tasks = new List<Task>();
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(imageDownloader.DownloaderAsync());
        }
        foreach (var item in tasks)
        {
            Examination(item);
        }
        await Task.WhenAll(tasks);

    }
}


//Делегаты
public delegate void EventStateDownload();
public delegate void StartExamDelegate(Task task);
