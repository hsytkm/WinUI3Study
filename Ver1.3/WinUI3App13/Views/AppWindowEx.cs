using Microsoft.UI;
using Microsoft.UI.Windowing;

namespace WinUI3App13.Views;

internal static class AppWindowEx
{
    /// <summary>
    /// タスクバーとアプリタイトルバー左上にアイコン(埋め込みリソース)を表示します
    /// </summary>
    internal static void SetAppIcon(this AppWindow appWindow, string resourceName)
    {
        // [WinUI3 Window Icon from EmbeddedResource / Resource · Issue #7782 · microsoft/microsoft-ui-xaml](https://github.com/microsoft/microsoft-ui-xaml/issues/7782)
        using var stream = typeof(App).Assembly.GetManifestResourceStream(resourceName);
        if (stream is null)
            return;

        // Iconを設定するためだけに System.Drawing.Common を参照しています…
        System.Drawing.Icon icon = new(stream);     // Disposeするとアイコンが表示されません
        appWindow.SetIcon(Win32Interop.GetIconIdFromIcon(icon.Handle));
    }

}
