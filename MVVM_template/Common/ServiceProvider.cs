using System;
using System.Windows;

namespace LagerLista.Common
{
    public static class ServiceProvider
    {
        public static IServiceProvider Instance
        {
            get
            {
                return (Application.Current as App).ServiceProvider;
            }
        }
    }
}
