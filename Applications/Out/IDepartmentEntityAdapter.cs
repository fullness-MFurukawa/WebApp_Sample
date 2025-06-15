using WebApp_Sample.Applications.Domains;
namespace WebApp_Sample.Applications.Out;
/// <summary>
/// ドメインモデル:部署と部署エンティティの相互変換インターフェイス
/// </summary>
/// <typeparam name="T">データベースエンティティ</typeparam>
public interface IDepartmentEntityAdapter<T>
{
    /// <summary>
    /// 部署エンティティからドメインモデル:部署を復元する
    /// </summary>
    /// <param name="entity">部署エンティティ</param>
    /// <returns>ドメインモデル:部署</returns>
    Department ToDomain(T entity);
    /// <summary>
    /// ドメインモデル:部署を部署エンティティに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:部署</param>
    /// <returns>部署エンティティ</returns>
    T ToEntity(Department domain);
}