# Study of WinUI3



### Unpackaged exe の発行

##### 2022/8/28

作業した内容をメモります。現時点では unpackaged.exe を発行できていません。

1. `*.csproj` に以下の行を追加すれば、WPF のような exe を 発行 から作成できる。[参考元](https://docs.microsoft.com/ja-jp/windows/apps/winui/winui3/create-your-first-winui3-app#non-msix-packaged-create-a-new-project-for-a-non-msix-packaged-c-or-c-winui-3-desktop-app)

```xml
<WindowsPackageType>None</WindowsPackageType>
```

2. 発行された exe を実行すると `Windows App Runtime Version 1.1 (MSIX package version >= 1004.584.2120.0)` が必要のウィンドウが出て起動しない。
3. PCにインストール済み Runtime を `get-appxpackage *appruntime*` で調べてみると、既に `x64` の `1004.584.2120.0` がインストールされてた。 ◆この時点で謎。
4. 念のため言われるとおりに [ここから入手した](https://docs.microsoft.com/ja-jp/windows/apps/windows-app-sdk/downloads) Windows App Runtime 1.1.4 のインストールを試みたけど `0x80073d02` により正常終了せず。


  ⇒ WPFのような Unpackaged な exe をリリースできず。

##### 2022/12/4

外販が落ち着き WPF 開発に酔ったので、WinUI3 について調べてみました。

8月に作業していたことすら忘れていましたが、作業をレジュームし unpackaged.exe の発行までできました。

まだ自己完結な単一ファイル の作成 ができていない状態です。 フレームワークとして提供されているかどうかも謎。

**対応メモ**

Unpackaged な exe を実行すると下記Exception が発生していましたが、

```
System.DllNotFoundException: 'Unable to load DLL 'Microsoft.ui.xaml.dll' or one of its dependencies:
```

*.csproj に以下を追加したら解決しました。

```xml
<WindowsAppSDKSelfContained>true</WindowsAppSDKSelfContained>
```

**備忘メモ**

x64 をデバッグ実行してアプリ×ボタンで閉じても完全にアプリが終了しない。 x86 なら期待通りアプリが終了するので、暫く x86 で耐えることにする。

##### 2023/3/18

GitHub にコミットしてなかったことに気づいたので、コミットした。

2022/12/4 の x64デバッグ実行で アプリ×ボタンが効かないの現象は、Nugetパッケージを更新しても解消しなかった🥲

以上