using WebApp_Sample.Applications.Domains.Departments;
using WebApp_Sample.Infrastructures.Entities;

namespace WebApp_Sample.Infrastructures.Adapters;

/// <summary>
/// ドメインモデル:部署と部署エンティティの相互変換インターフェイスの実装
/// </summary>
/// <typeparam name="T">DepartmentEntity</typeparam>
public class DepartmentEntityAdapter : IDepartmentAdapter<DepartmentEntity>
{
    /// <summary>
    /// ドメインモデル:部署を他のクラスに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:部署</param>
    /// <returns>DepartmentEntity</returns>
    public DepartmentEntity Convert(Department domain)
    {
        var entity = new DepartmentEntity{
            DeptName = domain.Name!,
        };
        if (domain.Id != null)
        {
            // int?（nullable int）から int への暗黙的な変換ができない
            // 明示的にValueを使う
            entity.DeptId = domain.Id.Value;
        }
        return entity;
    }
    /// <summary>
    /// 他のクラスからドメインモデル:部署を復元する
    /// </summary>
    /// <param name="otherModel">DepartmentEntity</param>
    /// <returns>ドメインモデル:部署</returns>
    public Department Restore(DepartmentEntity otherModel)
    {
        var department = new Department(otherModel.DeptId,otherModel.DeptName!);
        return department;
    }
}