using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2_Interface;

namespace Lab2_Gamming
{
    public class Gammirovanie : ICipher
    {
        public string Encode(string message, string key)  //шифровка сообщения
        {
            string result = ""; int i = 0;
            byte[] messageBytes = Encoding.Default.GetBytes(message); //  преобразование строки в байт
            byte[] keyBytes = Encoding.Default.GetBytes(key); // преобразование строки в байт (default определение кодировки на машине)
            foreach (byte item in messageBytes)
            {
                byte num = (byte)(item ^ keyBytes[i]);
                result += num + " ";
                if (i == keyBytes.Length - 1) { i = 0; }
            }
            return result; //вывод массива байт
        }
        public string Decode(string message, string key)//расшифровка сообщения
        {
            string result = "";
            string MyByte = "";
            List<byte> messageBytes = new List<byte>();
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i].ToString() != " ")
                {
                    MyByte += message[i].ToString();
                }
                else
                {
                    if (MyByte != "")
                    {
                        messageBytes.Add((byte)int.Parse(MyByte)); // преобразование строки в число
                        MyByte = "";
                    }
                }
            }
            if (MyByte != "") { messageBytes.Add((byte)int.Parse(MyByte)); } // проверка на законченность строки
            //-----------------------------------------------------------------------
            byte[] keyBytes = Encoding.Default.GetBytes(key); // преобразование строки в байт (default определение кодировки на машине)
            //-------------------------------------------------------------------------
            int j = 0;
            List<byte> myText = new List<byte>();
            foreach (byte item in messageBytes)
            {
                byte num = (byte)(item ^ keyBytes[j]);
                myText.Add(num);
                if (j == keyBytes.Length - 1) { j = 0; }
            }
            result = Encoding.Default.GetString(myText.ToArray()); // перевод символов в буквы
            return result;
        }
    }
}