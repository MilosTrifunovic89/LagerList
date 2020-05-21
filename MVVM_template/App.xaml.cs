using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LagerLista.Home;
using LagerLista.Main;
using System;
using System.Windows;
using LagerLista.Edit;

namespace LagerLista
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration ConfigurationProvider { get; private set; }

        public App()
        {
            ServiceProvider = createServiceProvider(ConfigurationProvider);
        }

        private IServiceProvider createServiceProvider(IConfiguration configuration)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IMainViewModel, MainViewModel>();
            serviceCollection.AddTransient<IHomeViewModel, HomeViewModel>();
            serviceCollection.AddTransient<IEditViewModel, EditViewModel>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
