using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Task6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введите путь к каталогу: ");  //string Path = Console.ReadLine();
            string Path = @"C:\Users\3213897\source\repos\12"; 
            Console.Write("Введите маску для файлов: ");  //string Mask = Console.ReadLine();
            string Maska = "*.txt";
            Console.Write("Введите текст для поиска в файлах: "); //string Text = Console.ReadLine();
            string Text = "Thread";
            Console.Write("Введите текст для замены в файлах: ");
            string ReplacementText = "Поток";

            // Дописываем слэш (в случае его отсутствия)
            if (Path[Path.Length - 1] != '\\') Path += '\\';

            // Создание объекта на основе введенного пути
            DirectoryInfo di = new (Path);
            // Если путь не существует
            if (!di.Exists)
            {
                Console.WriteLine("Некорректный путь!!!");
                return;
            }

            // Вызываем функцию поиска
            int y =  FindReplace.FindReplaceTextInFiles(di, Text, ReplacementText, Mask.MaskTransformToRegex(Maska));
            Console.WriteLine("Всего произведено замен: "+ y.ToString());

            Console.ReadKey();
        }
        // Функция поиска текста в файлах
        
       
    }
}
