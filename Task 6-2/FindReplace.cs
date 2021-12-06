using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task6_2
{
    internal class FindReplace
    {
        public static int FindReplaceTextInFiles(DirectoryInfo di, string Text, string ReplacementText, Regex regMask)
        {

            // Экранируем спецсимволы во введенном тексте
            Text = Regex.Escape(Text);
            // Создание объекта регулярного выражения на основе текста
            Regex regText = new Regex(Text, RegexOptions.IgnoreCase);
            ReplacementText = Regex.Escape(ReplacementText);
            Regex regReplacementText = new Regex(ReplacementText, RegexOptions.IgnoreCase);

            // Количество замен текста
            int CountOfMatch = 0;

            FileInfo[] fi = null;
            try
            {
                // Получаем список файлов
                fi = di.GetFiles();
            }
            catch
            {
                return CountOfMatch;
            }

            // Перебираем список файлов
            foreach (FileInfo f in fi)
            {
                // Если файл соответствует маске
                if (regMask.IsMatch(f.Name))
                {  // Поток для чтения из файла
                    StreamReader sr = null;
                    StreamWriter sw = null;
                    // Открываем файл
                    try
                    {
                        string CurrentLine = "";
                        sr = new StreamReader(di.FullName + @"\" + f.Name, Encoding.Default);
                        sw = new StreamWriter(di.FullName + @"\" + f.Name+"temp", false, Encoding.Default);
                        // Считываем построчно а не все сразу

                        while (!sr.EndOfStream)
                        {
                            CurrentLine = sr.ReadLine();
                            //Проверка наличия совпадений в строке
                            if (Regex.IsMatch(CurrentLine, Text))
                            {
                                CountOfMatch += new Regex(Text).Matches(CurrentLine).Count;
                                CurrentLine = Regex.Replace(CurrentLine, Text, ReplacementText);
                                
                            }
                            sw.WriteLine(CurrentLine);
                        }
                        // Закрываем файлы
                        sr.Close();
                        sw.Close();

                        File.Replace(di.FullName + @"\" + f.Name + "temp", di.FullName + @"\" + f.Name, null);




                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("The file cannot be found.");
                    }

                    catch (OutOfMemoryException)
                    {
                        Console.WriteLine("There is insufficient memory to read the file.");
                    }
                    finally
                    {
                        sr?.Dispose();
                        sw?.Dispose();
                    }
                }
            }
            return CountOfMatch;
        }

    }
}
