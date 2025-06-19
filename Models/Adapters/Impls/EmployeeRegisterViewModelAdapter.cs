using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Models;
namespace WebApp_Sample.Models.Adapters.Impls;
public class EmployeeRegisterViewModelAdapter : IFromViewModel<Employee, EmployeeRegisterForm>
{
    /// <summary>
    /// ViewModelをドメインオブジェクトに変換する
    /// </summary>
    /// <param name="viewModel">変換対象のViewModel</param>
    /// <returns>変換されたドメインオブジェクト</returns>
    Employee ToDomain(EmployeeRegisterForm viewModel)
    {
        var department = new Department(viewModel.DeptId!.Value);
        var employee = new Employee(viewModel.Name!, department);
        return employee;
    }
}