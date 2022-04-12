using System;
using Lab2_Interface;

namespace Lab2_VirgenerCipher
{
    public class Vijener : ICipher
    {
        private char[] alfabet = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё',
            'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
            'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

        public string Encode(string message, string key)
        {
            message = message.ToLower();
            key = key.ToLower();
            string result = "";

            int keyIndex = 0;  //индекс символа ключа
            int n = alfabet.Length; //мощность алфавита
            foreach (char letter in message)
            {
                //проверяем, является ли символ буквой русского алфавита
                if (Array.IndexOf(alfabet, letter) != -1)
                {
                    int c = (Array.IndexOf(alfabet, letter) +
                        Array.IndexOf(alfabet, key[keyIndex])) % n;

                    result += alfabet[c];

                    keyIndex++;

                    if (keyIndex == key.Length) keyIndex = 0;
                }
                //если символ сообщения не является буквой русского алфавита, то символ остается не изменным
                else result += letter;

            }
            return result;
        }
        public string Decode(string message, string key)//расшифровка сообщения
        {
            message = message.ToLower();
            key = key.ToLower();
            string result = "";

            int keyIndex = 0;//индекс символа ключа
            int n = alfabet.Length;//мощность алфавита
            foreach (char letter in message)
            {
                //проверяем, является ли символ буквой русского алфавита
                if (Array.IndexOf(alfabet, letter) != -1)
                {
                    int p = (Array.IndexOf(alfabet, letter) + n -
                    Array.IndexOf(alfabet, key[keyIndex])) % n;

                    result += alfabet[p];

                    keyIndex++;

                    if (keyIndex == key.Length) keyIndex = 0;
                }
                //если символ сообщения не является буквой русского алфавита, то символ остается не изменным
                else result += letter;
            }
            return result;
        }
    }
}