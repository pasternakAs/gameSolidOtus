using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    public interface IValidNumber : IValid
    {
        /// <summary>
        /// Проверка на число
        /// </summary>
        /// <param name="text">текст</param>
        /// <returns>true, если число; false, если нет</returns>
        bool IsNumber(string text);
    }
}
