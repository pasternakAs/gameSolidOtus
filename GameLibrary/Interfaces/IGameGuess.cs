using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    public interface IGameGuess : IGame
    {
        void GenerateNumber();
        void StartedGuessing();
        void NumberCheck(string text);
    }
}
