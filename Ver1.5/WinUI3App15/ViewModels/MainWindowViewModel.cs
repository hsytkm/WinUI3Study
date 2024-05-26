using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WinUI3App15.ViewModels;

public sealed partial class MainWindowViewModel : ObservableObject
{
    public string Title => App.IsUnPackaged ? "Unpackaged" : "Packaged";

    [ObservableProperty]
    int _counter = 0;

    public MainWindowViewModel()
    { }

    [RelayCommand]
    void CounterUp() => Counter++;

}
