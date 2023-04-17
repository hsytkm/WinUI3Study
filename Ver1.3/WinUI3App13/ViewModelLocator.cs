using Microsoft.Extensions.DependencyInjection;
using WinUI3App13.ViewModels;

namespace WinUI3App13;

internal sealed class ViewModelLocator
{
    private readonly IServiceProvider _container;

    internal ViewModelLocator()
    {
        var services = new ServiceCollection();

        services.AddTransient<MainWindowViewModel>();
        //services.AddSingleton<IStorageService, StorageService>();

        _container = services.BuildServiceProvider();
    }

    internal T GetViewModel<T>() where T : class
        => _container.GetRequiredService<T>()
            ?? throw new NotImplementedException($"{typeof(T).GetType().Name} is not registered.");

}
