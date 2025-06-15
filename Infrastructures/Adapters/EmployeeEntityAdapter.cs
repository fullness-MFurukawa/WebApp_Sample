using WebApp_Sample.Infrastructures.Entities;
using WebApp_Sample.Applications.Out;
using WebApp_Sample.Applications.Domains;
namespace WebApp_Sample.Infrastructures.Adapters;
/// <summary>
/// ドメインモデル:従業員と従業員エンティティの相互変換インターフェイスの実装
/// </summary>
/// <typeparam name="T">EmployeeEntity</typeparam>
public class EmployeeEntityAdapter : IEmployeeEntityAdapter<EmployeeEntity>
{
    /// <summary>
    /// 従業員エンティティからドメインモデル:従業員を復元する
    /// </summary>
    /// <param name="entity">従業員エンティティ</param>
    /// <returns>ドメインモデル:従業員</returns>
    public Employee ToDomain(EmployeeEntity entity)
    {
        var employee = new Employee(
            entity.EmpId,
            entity.EmpName,
            null
        );
        return employee;
    }
    /// <summary>
    /// ドメインモデル:従業員を従業員エンティティに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:従業員</param>
    /// <returns>従業員エンティティ</returns>
    public EmployeeEntity ToEntity(Employee domain)
    {
        var entity = new EmployeeEntity{
            EmpName = domain.Name
        };
        if (domain.Id != null){
            entity.EmpId = domain.Id.Value;
        }
        if (domain.Department != null)
        {
            entity.DeptId = domain.Department.Id;
        }
        return entity;
    }
}