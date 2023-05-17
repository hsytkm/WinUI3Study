using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Windows.Graphics;
using WinUI3App13.ViewModels;

namespace WinUI3App13.Views;

public sealed partial class MainWindow : Window
{
    public MainWindowViewModel ViewModel { get; } = App.ViewModelLocator.GetViewModel<MainWindowViewModel>();

    public MainWindow()
    {
        InitializeComponent();

        AppWindow.Resize(new SizeInt32(300, 200));

        // タスクバーとタイトルバーに影響するアイコンを表示します
        AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Resources/icon1.ico"));

        // タイトルバーのアイコンを隠します
        //AppWindow.TitleBar.IconShowOptions = IconShowOptions.HideIconAndSystemMenu;

        SystemBackdrop = GetSystemBackdrop();
    }

    private static SystemBackdrop? GetSystemBackdrop()
    {
        // [Windows 11 アプリで使用される素材 - Windows apps | Microsoft Learn](https://learn.microsoft.com/ja-jp/windows/apps/design/signature-experiences/materials)
        // アクリルは、ポップアップやコンテキスト メニューなどの、一時的に表示される簡易非表示サーフェスにのみ使用されます。
        // とのことなので、マイカを優先して使用しましょう。

        // [マイカ素材 - Windows apps | Microsoft Learn](https://learn.microsoft.com/ja-jp/windows/apps/design/style/mica)
        if (MicaController.IsSupported())
            return new MicaBackdrop();

        // [アクリル素材 - Windows apps | Microsoft Learn](https://learn.microsoft.com/ja-jp/windows/apps/design/style/acrylic)
        if (DesktopAcrylicController.IsSupported())
            return new DesktopAcrylicBackdrop();

        return null;
    }
}
