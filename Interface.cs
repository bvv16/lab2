using System;
using Lab2;
using Lab2_InputData;
using Lab2_VirgenerCipher;
using Lab2_Gamming;

namespace Lab2_Interface
{
    public interface ICipher
    {
        string Encode(string message, string key);
        string Decode(string message, string key);
    }

    public class Interface
    {
        public static ICipher ChoiceCipher()
        {
            ICipher cipher = null;
            Console.WriteLine("1) Шифр Вижененра.");
            Console.WriteLine("2) Гаммирование.");
            switch (InputData.ChoiceOption())
            {
                case(int)UserMenu.Vijener:
                    {
                        cipher = new Vijener();
                        Console.WriteLine("Шифрование применяется только к кириллице.");
                        break;
                    }
                case (int)UserMenu.Gammirovanie:
                    {
                        cipher = new Gammirovanie();
                        break;
                    }
            }
            return cipher;

        }

    }
}
