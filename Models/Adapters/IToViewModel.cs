/// <summary>
/// ドメインオブジェクトからViewModelへの変換を表すインターフェイス
/// 表示専用の画面や一覧出力など、ドメインオブジェクトからViewModelの片方向変換
/// </summary>
/// <typeparam name="TDomain">ドメインオブジェクトの型</typeparam>
/// <typeparam name="TViewModel">ViewModelの型</typeparam>
public interface IToViewModel<in TDomain, out TViewModel>
{
    /// <summary>
    /// ドメインオブジェクトをViewModelに変換する
    /// </summary>
    /// <param name="domain">変換対象のドメインオブジェクト</param>
    /// <returns>変換されたViewModel</returns>
    TViewModel ToViewModel(TDomain domain);
}