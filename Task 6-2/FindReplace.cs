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
                    // Открываем файл
                    try
                    {

                        sr = new StreamReader(di.FullName + @"\" + f.Name, Encoding.Default);
                        // Считываем построчно а не все сразу
                                              
                        string Content = sr.ReadToEnd();
                        sr.Close();
                        if (Regex.IsMatch(Content, Text))
                        {
                            CountOfMatch += new Regex(Text).Matches(Content).Count;
                            Content = Regex.Replace(Content, Text, ReplacementText);
                            StreamWriter sw = new StreamWriter(di.FullName + @"\" + f.Name, false, Encoding.Default);
                            sw.Write(Content);
                            sw.Close();
                        }

                        // Закрываем файл
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
                    }
                }
            }
            return CountOfMatch;
        }

    }
}
