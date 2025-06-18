namespace WebApp_Sample.Applications.Domains.Employees;

/// <summary>
/// ドメインモデル:従業員と他のクラスの相互変換インターフェイス
/// </summary>
/// <typeparam name="T">相互変換クラス</typeparam>
public interface IEmployeeEntityAdapter<T>
{
    /// <summary>
    /// 他のクラスからドメインモデル:従業員を復元する
    /// </summary>
    /// <param name="otherModel">変換元クラス</param>
    /// <returns>ドメインモデル:従業員</returns>
    Employee Restore(T otherModel);
    /// <summary>
    /// ドメインモデル:従業員を他のクラスに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:従業員</param>
    /// <returns>変換先クラス</returns>
    T Convert(Employee domain);
}