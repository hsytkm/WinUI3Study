using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3App15;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private Window? m_window;
    internal static ViewModelLocator ViewModelLocator { get; } = new();

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        m_window = new Views.MainWindow();
        m_window.Activate();
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
