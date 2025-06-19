using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Models;
namespace WebApp_Sample.Models.Adapters.Impls;
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