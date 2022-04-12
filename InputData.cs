using System;

namespace Lab2_InputData
{
    class InputData
    {
        enum UserMenu
        {
            FirstItem = 1,
            SecondItem = 2,
            ContinueWork = 1,
            NewMessage = 2
        }
        public static int ChoiceOption()  //ввод номера пункта меню
        {
            string optionInput;
            int option;
            while (true)
            {
                optionInput = Console.ReadLine();
                if (!int.TryParse(optionInput, out option))
                {
                    Console.WriteLine("Некорректное значение! Попробуйте снова.");
                    continue;
                }
                if (option < (int)UserMenu.FirstItem || option > (int)UserMenu.SecondItem)
                {
                    Console.WriteLine("Нет такого пункта меню! Попробуйте снова.");
                    continue;
                }
                return option;
            }
        }
        public static string InputMessage() //ввод сообщения
        {
            string message = null;
            Console.WriteLine("Введите сообщение:");
            message = Console.ReadLine();
            return message;
        }
        public static string InputKey()
        {
            string rusAlfabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string key = null;
            bool successInput = false;
            while (!successInput)
            {
                Console.WriteLine("Введите ключ:");
                key = Console.ReadLine();
                foreach (char letter in key)
                {
                    //проверка, являются ли символы ключа буквами русского алфавита
                    if (rusAlfabet.IndexOf(letter) == -1)
                    {
                        Console.WriteLine("Некорректный ввод! Используйте буквы русского алфавита." +
                            "Попробуйте снова.");
                        key = null;
                        successInput = false;
                        break;
                    }
                    else successInput = true;
                }
            }
            return key;
        }
    }
}