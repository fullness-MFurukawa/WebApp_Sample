using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Applications.Adapters;
using WebApp_Sample.Infrastructures.Entities;
namespace WebApp_Sample.Infrastructures.Adapters;
/// <summary>
/// ドメインモデル:従業員と従業員エンティティの相互変換インターフェイスの実装
/// </summary>
/// <typeparam name="TEntity">EmployeeEntity</typeparam>
public class EmployeeEntityAdapterA : IEmployeeAdapter<EmployeeEntity>
{
    /// <summary>
    /// ドメインモデル:従業員をEmployeeEntityに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:従業員</param>
    /// <returns>EmployeeEntity</returns>
    public EmployeeEntity Convert(Employee domain)
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
    /// <summary>
    /// EmployeeEntityからドメインモデル:従業員を復元する
    /// </summary>
    /// <param name="entity">EmployeeEntity</param>
    /// <returns>ドメインモデル:従業員</returns>
    public Employee Restore(EmployeeEntity entity)
    {
        var employee = new Employee(
            entity.EmpId,
            entity.EmpName,
            null
        );
        return employee;
    }
}