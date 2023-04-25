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

        // タスクバーとタイトルバーにアイコンを表示します
        AppWindow.SetAppIcon("WinUI3App13.Resources.icon1.ico");  // [ProjName].[RelativePath]

        // タイトルバーのアイコンを隠します
        AppWindow.TitleBar.IconShowOptions = IconShowOptions.HideIconAndSystemMenu;

#if false
        // [マイカ素材 - Windows apps | Microsoft Learn](https://learn.microsoft.com/ja-jp/windows/apps/design/style/mica)
        if (MicaController.IsSupported())
            SystemBackdrop = new MicaBackdrop();
#else
        // [アクリル素材 - Windows apps | Microsoft Learn](https://learn.microsoft.com/ja-jp/windows/apps/design/style/acrylic)
        if (DesktopAcrylicController.IsSupported())
            SystemBackdrop = new DesktopAcrylicBackdrop();
#endif
    }
}
