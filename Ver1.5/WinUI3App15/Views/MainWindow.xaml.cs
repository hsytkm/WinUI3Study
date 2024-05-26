using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Windows.Graphics;
using WinUI3App15.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3App15.Views;

public sealed partial class MainWindow : Window
{
    public MainWindowViewModel ViewModel { get; } = App.ViewModelLocator.GetViewModel<MainWindowViewModel>();

    public MainWindow()
    {
        InitializeComponent();

        AppWindow.Resize(new SizeInt32(300, 200));

        // �^�X�N�o�[�ƃ^�C�g���o�[�ɉe������A�C�R����\�����܂�
        // �t�@�C���p�X���w�肷������Ȃ̂ŒP��exe�ŕ\������܂���B���ߍ��݃��\�[�X����ݒ肵�����ł������@���������Ă��܂���B
        AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Resources/icon1.ico"));

        // �^�C�g���o�[�̃A�C�R�����B���܂�
        //AppWindow.TitleBar.IconShowOptions = IconShowOptions.HideIconAndSystemMenu;

        SystemBackdrop = GetSystemBackdrop();
    }

    private static SystemBackdrop? GetSystemBackdrop()
    {
        // [Windows 11 �A�v���Ŏg�p�����f�� - Windows apps | Microsoft Learn](https://learn.microsoft.com/ja-jp/windows/apps/design/signature-experiences/materials)
        // �A�N�����́A�|�b�v�A�b�v��R���e�L�X�g ���j���[�Ȃǂ́A�ꎞ�I�ɕ\�������ȈՔ�\���T�[�t�F�X�ɂ̂ݎg�p����܂��B
        // �Ƃ̂��ƂȂ̂ŁA�}�C�J��D�悵�Ďg�p���܂��傤�B

        // [�}�C�J�f�� - Windows apps | Microsoft Learn](https://learn.microsoft.com/ja-jp/windows/apps/design/style/mica)
        if (MicaController.IsSupported())
            return new MicaBackdrop();

        // [�A�N�����f�� - Windows apps | Microsoft Learn](https://learn.microsoft.com/ja-jp/windows/apps/design/style/acrylic)
        if (DesktopAcrylicController.IsSupported())
            return new DesktopAcrylicBackdrop();

        return null;
    }
}
