using System;
using System.IO;
using Lab2_InputData;

namespace Lab2_FileWork
{
    enum Choice
    {
        Yes = 1,
        No
    }
    class FileWork
    {
        public static string InputPath() //ввод адреса файла
        {
            while (true)
            {
                Console.WriteLine("Введите адрес файла:");
                string path = Console.ReadLine();
                if (path.EndsWith(".txt") || path.EndsWith(".TXT"))//проверка расширения файла
                    return path;
                else
                {
                    Console.WriteLine("Файл должен быть расширения txt!");
                    continue;
                }
            }
        }
        public static bool CheckFileIsReadOnly(string path)//проверка, допуступен ли файл только для чтения
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.IsReadOnly)
            {
                Console.WriteLine("Данный файл доступен только для чтения!");
                return true;
            }
            return false;
        }
        public static string ReadMessage()
        {
            while (true)
            {
                string path = InputPath();//ввод адреса файла
                if (File.Exists(path)) //проверка на существование файла
                {
                    string message = File.ReadAllText(path);//чтение всего текста из файла
                    if (message.Length == 0)//проверка, есть ли в файле данные
                    {
                        Console.WriteLine("В файле нет данных!");
                        continue;
                    }
                    else return message;
                }
                else Console.WriteLine("Файл не найден!");
            }
        }

        public static void WriteMessage(string message)//запись сообщения в файл
        {
            while (true)
            {
                string path = InputPath();//ввод адреса файла
                if (File.Exists(path))//проверка на существования файла
                {
                    Console.WriteLine("Данный файл уже существует! Желаете создать новый файл или перезаписать этот файл?");
                    Console.WriteLine("1) Создать новый файл.\n2) Перезаписать этот.");
                    if (InputData.ChoiceOption() == (int)Choice.Yes) continue;
                    else//перезапись существующего файла
                    {
                        if (!CheckFileIsReadOnly(path))//проверка на допуск к записи
                        {
                            File.WriteAllText(path, message);//запись результата в файл
                            Console.WriteLine("Результат успешно записан в файл!");
                            break;
                        }
                        else continue;
                    }
                }
                else//создание файла
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine(message);
                        }
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Недопустимое имя файла!");
                        continue;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Запрещен доступ к файлу!");
                        continue;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine("Файл не найден!");
                        continue;
                    }
                    catch (System.Security.SecurityException)
                    {
                        Console.WriteLine("Ошибка безопасности!");
                        continue;
                    }
                    catch (NotSupportedException)
                    {
                        Console.WriteLine("Данный файл не является текстовым файлом!");
                        continue;
                    }
                    Console.WriteLine("Результат успешно записан в файл!");
                    break;
                }

            }
        }
    }
}