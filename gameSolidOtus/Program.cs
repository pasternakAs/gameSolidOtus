using GameLibrary;
using GameLibrary.Interfaces;
using GameLibrary.Writer;
using gameSolidOtus;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    /// <summary>
    /// 
    /// </summary>
    static void Main()
    {
        GameGuessNumber();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void GameGuessNumber()
    {
        var services = new ServiceCollection();

        services.AddTransient<IWriter, ConsoleWriter>();
        services.AddTransient<IValidNumber, ValidNumber>();
        services.AddTransient<GameClass>();
        var container = services.BuildServiceProvider(true);

        var app = container.GetRequiredService<GameClass>();
        app.Run();

        //var writer = new ConsoleWriter();
        //var app = new GameClass(writer);
        //app.Run();
    }
}