using WebApp_Sample.Applications.Domains;
namespace WebApp_Sample.Applications.Adapters;
/// <summary>
/// ドメインモデル:部署と他のクラスの相互変換インターフェイス
/// </summary>
/// <typeparam name="TEntity">相互変換Entityクラス</typeparam>
public interface IDepartmentAdapter<TEntity>
{
    /// <summary>
    /// 他のクラスからドメインモデル:部署を復元する
    /// </summary>
    /// <param name="entity">変換元クラス</param>
    /// <returns>ドメインモデル:部署</returns>
    Department Restore(TEntity entity);

    /// <summary>
    /// ドメインモデル:部署を他のクラスに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:部署</param>
    /// <returns>変換先クラス</returns>
    TEntity Convert(Department domain);
}