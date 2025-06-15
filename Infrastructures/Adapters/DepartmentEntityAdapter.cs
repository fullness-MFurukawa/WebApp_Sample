using WebApp_Sample.Infrastructures.Entities;
using WebApp_Sample.Applications.Out;
using WebApp_Sample.Applications.Domains;
namespace WebApp_Sample.Infrastructures.Adapters;
/// <summary>
/// ドメインモデル:部署と部署エンティティの相互変換インターフェイスの実装
/// </summary>
/// <typeparam name="T">DepartmentEntity</typeparam>
public class DepartmentEntityAdapter : IDepartmentEntityAdapter<DepartmentEntity>
{
    /// <summary>
    /// 部署エンティティからドメインモデル:部署を復元する
    /// </summary>
    /// <param name="entity">部署エンティティ</param>
    /// <returns>ドメインモデル:部署</returns>
    public Department ToDomain(DepartmentEntity entity)
    {
        var department = new Department(entity.DeptId,entity.DeptName!);
        return department;
    }
    /// <summary>
    /// ドメインモデル:部署を部署エンティティに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:部署</param>
    /// <returns>部署エンティティ</returns>
    public DepartmentEntity ToEntity(Department domain)
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
}