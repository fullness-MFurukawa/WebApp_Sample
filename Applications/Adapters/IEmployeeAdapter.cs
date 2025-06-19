using WebApp_Sample.Applications.Domains;
namespace WebApp_Sample.Applications.Adapters;
/// <summary>
/// ドメインモデル:従業員と他のクラスの相互変換インターフェイス
/// </summary>
/// <typeparam name="TEntity">相互変換Entityクラス</typeparam>
public interface IEmployeeAdapter<TEntity>
{
    /// <summary>
    /// 他のクラスからドメインモデル:従業員を復元する
    /// </summary>
    /// <param name="entity">変換元Entityクラス</param>
    /// <returns>ドメインモデル:従業員</returns>
    Employee Restore(TEntity entity);
    /// <summary>
    /// ドメインモデル:従業員を他のクラスに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:従業員</param>
    /// <returns>変換先Entityクラス</returns>
    TEntity Convert(Employee domain);
}