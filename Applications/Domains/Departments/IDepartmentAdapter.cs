namespace WebApp_Sample.Applications.Domains.Departments;

/// <summary>
/// ドメインモデル:部署と他のクラスの相互変換インターフェイス
/// </summary>
/// <typeparam name="T">相互変換クラス</typeparam>
public interface IDepartmentAdapter<T>
{
    /// <summary>
    /// 他のクラスからドメインモデル:部署を復元する
    /// </summary>
    /// <param name="otherModel">変換元クラス</param>
    /// <returns>ドメインモデル:部署</returns>
    Department Restore(T otherModel);

     /// <summary>
    /// ドメインモデル:部署を他のクラスに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:部署</param>
    /// <returns>変換先クラス</returns>
    T Convert(Department domain);
}