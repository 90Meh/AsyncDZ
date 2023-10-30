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
    static async Task<Task> Examination(Task task)
    {
        var answer = Console.ReadKey().KeyChar;

        Console.WriteLine();
        if (answer != 65)
        {
            if (!task.IsCompletedSuccessfully)
            {
                Console.WriteLine($"Ещё скачивается{task.Id}");
            }
            else
            {
                Console.WriteLine($"Загрузка завершена{task.Id}");
            }

            Examination(task);
        }

        return task;
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

        Console.Clear();
        Console.WriteLine("Нажмите любую кнопку");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");


        List<Task> tasks = new List<Task>();
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(imageDownloader.DownloaderAsync());
        }

        foreach (var item in tasks)
        {
            Task.Factory.StartNew(async () =>
            {
                await Examination(item);
            });
        }
        do
        {

        } while (!Task.WhenAll(tasks).IsCompleted);
    }
}


//Делегаты
public delegate void EventStateDownload();
public delegate Task StartExamDelegate(Task task);
