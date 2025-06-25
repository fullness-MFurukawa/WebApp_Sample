using WebApp_Sample.Applications.Adapters;
using WebApp_Sample.Applications.Domains;
namespace WebApp_Sample.Models.Adapters;
/// <summary>
/// EmployeeRegisterForm(従業員登録ViewModel)を
/// ドメインオブジェクト:Employeeに変換するアダプターインターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">Employee</typeparam>
/// <typeparam name="TTarget">EmployeeRegisterForm</typeparam>
public class EmployeeRegisterFormAdapter : IRestorer<Employee, EmployeeRegisterForm>
{
    /// <summary>
    /// EmployeeRegisterFormをドメインオブジェクト:Employeeに変換する
    /// </summary>
    /// <param name="target">EmployeeRegisterForm</param>
    /// <returns>ドメインオブジェクト:Employee</returns>
    public Employee Restore(EmployeeRegisterForm target)
    {
        var department = new Department(target.DeptId!.Value);
        var employee = new Employee(target.Name!, department);
        return employee;
    }
}