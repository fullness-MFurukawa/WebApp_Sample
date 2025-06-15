using WebApp_Sample.Applications.Domains;
namespace WebApp_Sample.Applications.Out;
/// <summary>
/// ドメインモデル:従業員と従業員エンティティの相互変換インターフェイス
/// </summary>
/// <typeparam name="T">データベースエンティティ</typeparam>
public interface IEmployeeEntityAdapter<T>
{
    /// <summary>
    /// 従業員エンティティからドメインモデル:従業員を復元する
    /// </summary>
    /// <param name="entity">従業員エンティティ</param>
    /// <returns>ドメインモデル:従業員</returns>
    Employee ToDomain(T entity);
    /// <summary>
    /// ドメインモデル:従業員を従業員エンティティに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:従業員</param>
    /// <returns>従業員エンティティ</returns>
    T ToEntity(Employee domain);
}