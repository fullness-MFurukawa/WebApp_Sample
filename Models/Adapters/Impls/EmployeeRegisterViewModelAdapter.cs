using WebApp_Sample.Applications.Domains;
namespace WebApp_Sample.Models.Adapters.Impls;
/// <summary>
/// 従業員登録ViewModelをドメインオブジェクト:従業員に変換するアダプターインターフェイスの実装
/// </summary>
public class EmployeeRegisterViewModelAdapter : IFromViewModel<Employee, EmployeeRegisterForm>
{
    /// <summary>
    /// ViewModelをドメインオブジェクト:従業員に変換する
    /// </summary>
    /// <param name="viewModel">EmployeeRegisterForm</param>
    /// <returns>ドメインオブジェクト:従業員</returns>
    public Employee ToDomain(EmployeeRegisterForm viewModel)
    {
        var department = new Department(viewModel.DeptId!.Value);
        var employee = new Employee(viewModel.Name!, department);
        return employee;
    }
}