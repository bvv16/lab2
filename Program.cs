using System;
using Lab2_InputData;
using Lab2_FileWork;
using Lab2_Interface;
using Lab2_VirgenerCipher;

namespace Lab2
{
    enum UserMenu
    {
        Vijener = 1,
        Gammirovanie = 2,
        Encode = 1,
        Decode = 2,
        Keyboard = 1,
        ReadFile = 2,
        Yes = 1,
        No = 2
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // изменение кодировки
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Лабораторная работа №2");    
            Console.WriteLine("Студентка группы №405 Быкова Виталина Витальевна");
            Console.WriteLine("ШИФРОВКА И РАСШИФРОВКА СООБЩЕНИЙ С ПОМОЩЬЮ ГАММИРОВАНИЯ И ШИФРА ВИЖЕНЕРА");  
            string newLine = Environment.NewLine;
            string message = "";
            string key;
            ICipher cipher;
            while (true)
            {
                cipher = Interface.ChoiceCipher();
                Console.WriteLine("1) Зашифровать сообщение.");
                Console.WriteLine("2) Расшифровать сообщение.");
                switch (InputData.ChoiceOption())
                {
                    case (int)UserMenu.Encode://шифрование сообщения
                        {
                            Console.WriteLine("Выберите способ ввода сообщения:");
                            Console.WriteLine("1) Ввести с клавиатуры.");
                            Console.WriteLine("2) Считать из файла.");
                            switch (InputData.ChoiceOption())
                            {
                                case (int)UserMenu.Keyboard://ввод сообщения с клавиатуры
                                    message = InputData.InputMessage();
                                    Console.WriteLine("Желаете сохранить сообщение в файле?");
                                    Console.WriteLine("1) Да.");
                                    Console.WriteLine("2) Нет.");
                                    if (InputData.ChoiceOption() == (int)UserMenu.Yes)
                                        FileWork.WriteMessage(message);
                                    break;
                                case (int)UserMenu.ReadFile://считывание сообщения из файла
                                    message = FileWork.ReadMessage();
                                    Console.WriteLine("Сообщение:" + newLine + message);
                                    break;
                            }

                            key = InputData.InputKey();//ввод ключа
                            string encryptedMessage = cipher.Encode(message, key);//расшифровка сообщения
                            Console.WriteLine(newLine + "Зашифрованное сообщение:");
                            Console.WriteLine(encryptedMessage + "\n");
                            Console.WriteLine("Желаете сохранить зашифрованное сообщение в файл?\n");
                            Console.WriteLine("1) Да");
                            Console.WriteLine("2) Нет.");
                            if (InputData.ChoiceOption() == (int)UserMenu.Yes)
                                FileWork.WriteMessage(encryptedMessage);//сохранение сообщения в файл

                        }
                        break;

                    case (int)UserMenu.Decode://расшифровка сообщения
                        Console.WriteLine("Выберите способ ввода сообщения:");
                        Console.WriteLine("1) Ввести с клавиатуры.");
                        Console.WriteLine("2) Считать из файла.");
                        switch (InputData.ChoiceOption())
                        {
                            case (int)UserMenu.Keyboard://ввод сообщения с клавиатуры
                                message = InputData.InputMessage();
                                Console.WriteLine("Желаете сохранить сообщение в файле?");
                                Console.WriteLine("1) Да.");
                                Console.WriteLine("2) Нет.");
                                if (InputData.ChoiceOption() == (int)UserMenu.Yes)
                                    FileWork.WriteMessage(message);
                                break;
                            case (int)UserMenu.ReadFile://считывание сообщения из файла
                                message = FileWork.ReadMessage();
                                Console.WriteLine("Сообщение:");
                                Console.WriteLine(message);
                                break;
                        }
                        key = InputData.InputKey();//ввод ключа
                        string decryptedMessage = cipher.Decode(message, key);//расшифровка сообщения
                        Console.WriteLine("Расшифрованное сообщение:");
                        Console.WriteLine(decryptedMessage + "\n");
                        Console.WriteLine("Желаете сохранить расшифрованное сообщение в файл?");
                        Console.WriteLine("1) Да.");
                        Console.WriteLine("2) Нет.");
                        if (InputData.ChoiceOption() == (int)UserMenu.Yes)
                            FileWork.WriteMessage(decryptedMessage);//сохранение сообщения в файл
                        break;
                }

                Console.WriteLine("Желаете продолжить работу?");
                Console.WriteLine("1) Да.");
                Console.WriteLine("2) Нет.");
                if (InputData.ChoiceOption() == (int)UserMenu.No) return;
            }
        }
    }
}