using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Windows.Graphics;
using WinRT.Interop;
using WinUI3App13.ViewModels;

namespace WinUI3App13.Views;

public sealed partial class MainWindow : Window
{
    public MainWindowViewModel ViewModel { get; } = App.ViewModelLocator.GetViewModel<MainWindowViewModel>();

    public MainWindow()
    {
        InitializeComponent();
        SetWindowSize(this, 300, 200);
    }

    // ここまでしないとウィンドウサイズを変更できないん？
    static void SetWindowSize(Window window, int width, int height)
    {
        IntPtr hwnd = WindowNative.GetWindowHandle(window);
        WindowId windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
        AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
        appWindow.Resize(new SizeInt32(width, height));
    }
}