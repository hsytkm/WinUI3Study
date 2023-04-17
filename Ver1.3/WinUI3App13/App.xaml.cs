using Microsoft.UI.Xaml;

namespace WinUI3App13;

public partial class App : Application
{
    private Window? _window;
    internal static ViewModelLocator ViewModelLocator { get; } = new();

    public App() => InitializeComponent();

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        _window = new Views.MainWindow();
        _window.Activate();
    }

    // 実行ファイルが Packaged かどうかを判定します
    // [WinUI 3 | How to check if app is packaged or non-packaged](https://www.youtube.com/watch?v=yW5dUCf4Ycg&ab_channel=AndrewKeepCoding)
    public const bool IsUnPackaged =
#if IS_NON_PACKAGED
        true;
#else
        false;
#endif
}