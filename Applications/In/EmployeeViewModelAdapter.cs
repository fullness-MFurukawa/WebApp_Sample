using WebApp_Sample.Applications.Domains;
namespace WebApp_Sample.Applications.In;
/// <summary>
/// ドメインモデル:従業員と従業員ViewModel相互変換インターフェイス
/// </summary>
/// <typeparam name="T">従業員ViewModel</typeparam>
public interface IEmployeeViewModelAdapter<T>
{
    /// <summary>
    /// 従業員ViewModelからドメインモデル:従業員に変換する
    /// </summary>
    /// <param name="viewModel">従業員ViewModel</param>
    /// <returns>ドメインモデル:従業員</returns>
    Employee ToDomain(T viewModel);
}