/// <summary>
/// ViewModelからドメインオブジェクトへの変換を表すインターフェイス
/// 登録・編集画面など、ViewModel→ドメインの片方向変換
/// </summary>
/// <typeparam name="TDomain">ドメインオブジェクトの型</typeparam>
/// <typeparam name="TViewModel">ViewModelの型</typeparam>
public interface IFromViewModel<out TDomain, in TViewModel>
{
    /// <summary>
    /// ViewModelをドメインオブジェクトに変換する
    /// </summary>
    /// <param name="viewModel">変換対象のViewModel</param>
    /// <returns>変換されたドメインオブジェクト</returns>
    TDomain ToDomain(TViewModel viewModel);
}