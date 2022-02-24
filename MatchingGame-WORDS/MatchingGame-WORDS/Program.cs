using MatchingGame_WORDS.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MatchingGame_WORDS
{
    public class Program
    {

        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var menu = ServiceProvider.GetService<IMenu>();
            menu.MainMenu();
            menu.GameOverMenu();
        }
        public static ServiceProvider ServiceProvider { get; private set; }
        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IMenu, Menu>()
                .AddSingleton<IGameFactory, GameFactory>()
                .AddSingleton<DataService>()
                .AddSingleton<Score>();
        }

    }
}
