using GameLibrary.Interfaces;

namespace gameSolidOtus
{
    public class GameClass : IGame, INumberAttempts, INumberRange
    {
        private int _numberAttempts;
        private int _minRange;
        private int _maxRange;
        private int _generateNumber;
        private bool _isGuessed;

        private readonly IWriter _messageWriter;
        private readonly IValidNumber _validNumber;
        readonly char[] delimiterChars = [' ', ',', '.', ':', '\t'];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageWriter"></param>
        public GameClass(IWriter messageWriter, IValidNumber validNumber)
        {
            _messageWriter = messageWriter;
            _validNumber = validNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            _messageWriter.Write("Привет!");
            _messageWriter.Write("Да начнется игра!");

            SetNumberAttempts();
            SetNumberRange();
            GenerateNumber();

            _messageWriter.Write("Число загадано. Время угадать!");
            _messageWriter.Write("Введите число:");

            StartedGuessing();

            //_messageWriter.Write("Повторить?(Y/N)");
            //Console.ReadLine(); 
        }

        /// <summary>
        /// Число попыток
        /// </summary>
        public void SetNumberAttempts()
        {
            _messageWriter.Write("Введите число попыток: ");
            var text = Console.ReadLine() ?? "";

            if (_validNumber.IsNumber(text))
            {
                _numberAttempts = Convert.ToInt32(text);

                if (_numberAttempts < 1)
                {
                    _messageWriter.Write("Необходимо ввести число больше нуля!");
                    SetNumberAttempts();
                }
            }
            else
            {
                _messageWriter.Write("Не удалось распознать число, попробуйте еще раз.");
                SetNumberAttempts();
            }
        }

        /// <summary>
        /// Установка диапазона 
        /// </summary>
        public void SetNumberRange()
        {
            _messageWriter.Write("Введите минимальное и максимальное число диапазона: ");
            var text = Console.ReadLine() ?? "";
            string[] words = text.Split(delimiterChars);

            if (!_validNumber.IsNumber(words[0]))
            {
                _messageWriter.Write("Не удалось распознать минимальное число диапазона, попробуйте еще раз.");
                SetNumberRange();
            }

            if (!_validNumber.IsNumber(words[1]))
            {
                _messageWriter.Write("Не удалось распознать максимальное число диапазона, попробуйте еще раз.");
                SetNumberRange();
            }

            _minRange = Convert.ToInt32(words[0]);
            _maxRange = Convert.ToInt32(words[1]);
        }

        /// <summary>
        /// Генератор числа
        /// </summary>
        private void GenerateNumber()
        {
            var rnd = new Random();
            _generateNumber = rnd.Next(_minRange, _maxRange);
        }

        /// <summary>
        /// проверка угадал или нет
        /// </summary>
        /// <param name="text"></param>
        private void NumberCheck(string text)
        {
            var number = Convert.ToInt32(text);

            if (number == _generateNumber)
            {
                _messageWriter.Write("Вы угадали!");
                _isGuessed = true;
            }
            else if (number > _generateNumber)
            {
                _messageWriter.Write("Попробуй число поменьше.");
                _isGuessed = false;
            }
            else
            {
                _messageWriter.Write("Попробуй число побольше.");
                _isGuessed = false;
            }
        }

        /// <summary>
        /// Запуск игры
        /// </summary>
        private void StartedGuessing()
        {
            for (int i = 0; i < _numberAttempts; i++)
            {
                --_numberAttempts;
                var text = Console.ReadLine() ?? "";

                while (!_validNumber.IsNumber(text))
                {
                    _messageWriter.Write("Не удалось распознать число, попробуйте еще раз.");
                    _messageWriter.Write("Введите число:");
                }

                NumberCheck(text);

                if (_isGuessed) return;

                if (_numberAttempts == 0) 
                {
                    _messageWriter.Write("Вы не угадали! Конец игры.");
                    return;
                }

                _messageWriter.Write($@"Осталось {_numberAttempts} попыток!");
                _messageWriter.Write("Введите число:");
            }
        }
    }
}
