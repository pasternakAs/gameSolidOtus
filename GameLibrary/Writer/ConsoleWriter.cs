using GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Writer
{
    public class ConsoleWriter : IWriter
    {
        /// <summary>
        /// Вывод консоль сообщения
        /// </summary>
        /// <param name="message">сообщение</param>
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
