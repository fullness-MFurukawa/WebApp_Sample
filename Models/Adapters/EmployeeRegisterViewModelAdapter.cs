using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Applications.In;

namespace WebApp_Sample.Models.Adapters;
/// <summary>
/// 従業登録ViewModelからドメインオブジェクト:従業員に変換するインターフェイスの実装
/// </summary>
public class EmployeeRegisterViewModelAdapter : IEmployeeViewModelAdapter<EmployeeRegisterForm>
{
    /// <summary>
    /// 従業登録ViewModelからドメインオブジェクト:従業員に変換する
    /// </summary>
    /// <param name="viewModel">従業登録ViewModel</param>
    /// <returns></returns>
    public Employee ToDomain(EmployeeRegisterForm viewModel)
    {
        var department = new Department(viewModel.DeptId!.Value);
        var employee = new Employee(viewModel.Name!, department);
        return employee;
    }
}