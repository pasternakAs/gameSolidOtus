using GameLibrary.Interfaces;

namespace GameLibrary
{
    public class ValidNumber : IValidNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool IsEmpty(string text)
        {
            return string.IsNullOrEmpty(text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool IsNumber(string text)
        {
            return int.TryParse(text, out int number);
        }
    }
}
