# Study of WinUI3 Ver1.3

2023.4.16

以前の調査(Ver1.2)から半年が経って全ての記憶を失いました。開発環境の構築すら分からない状態になりましたが、以前の調査時にその辺りを残していなかったので、一からまとめ直します。



## 前回(Ver1.2)の調査内容のおさらい

<u>できていたこと</u>

- WPF のような Unpackage かつ SelfContained な exe を作成できた。

  ```xml
  <!-- .csproj  -->
  <WindowsPackageType>None</WindowsPackageType>
  <WindowsAppSDKSelfContained>true</WindowsAppSDKSelfContained>
  ```

<u>できていなかったこと</u>

- x64 のデバッグ実行で アプリ×ボタンが効かない（x86 は問題なし） ← Ver1.2 で解消してました (2023.4.16)
- リリース.exe をSingleFile にできない。フレームワークとして提供されてるかすら謎。 ← 未解決です (2023.4.16)

## WinUI3 の開発環境の構築

[Windows App SDK 用のツールをインストールする - Windows apps | Microsoft Learn](https://learn.microsoft.com/ja-jp/windows/apps/windows-app-sdk/set-up-your-development-environment) を参照にしました。 読むのが面倒なので以下にざっくりまとめます。（次に必要な機会には手順が変わってそうですが…）

1. VisualStudio2022 をインストールします
2. ワークロード → .NET デスクトップ開発 を選択します
3. インストールの詳細 → Windows アプリ SDK C# テンプレート を選択します
4. 個別のコンポーネント → Windows 10 SDK (10.0.19041.0) を選択します。※参照元の指示Version。最新候補は Windows 11 SDK (10.0.22621.0) でした。
5. VisualStudio内の拡張機能から WinUI3 ~ Template Extension を全部インストールする。（ここはテキトー）

## アプリインフラ

##### Unpackaged リリース時の不要な言語フォルダ削除

[WinUI 3 | Auto-removing language folders | WinAppSDK | XAML | C# | .NET | UWP | WPF - YouTube](https://www.youtube.com/watch?v=LHNahJi21Vg&t=29s&ab_channel=AndrewKeepCoding)

```xaml
<!-- .csproj -->
<Target Name="RemoveFoldersWithMuiFiles" AfterTargets="Build" >
  <ItemGroup>
    <RemovingFiles Include="$(OutDir)*\*.mui" Exclude="$(OutDir)ja-jp\*.mui" />
    <RemovingFolders Include="@(RemovingFiles->'%(RootDir)%(Directory)')" />
  </ItemGroup>
  <RemoveDir Directories="@(RemovingFolders)" />
</Target>
```



## アプリ実装

- ViewModel に `INotifyPropertyChanged` を継承させるのは同じっぽい。 MVVM やし当然なのかも。
- MVVM インフラは、CommunityToolkit.Mvvm を導入すればよさそう。（WPF での学習が役に立って良かった）
- DI は、Microsoft.Extensions.DependencyInjection でよさそう。（こちらも流用できた）
- 

## 困ってること

1. Single Exe を作成できない！！
3. 

## References

[Andrew KeepCoding - YouTube](https://www.youtube.com/@AndrewKeepCoding)

