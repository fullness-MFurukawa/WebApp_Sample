using WebApp_Sample.Applications.Repositories;
using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Exceptions;
namespace WebApp_Sample.Applications.Services.Impls;
/// <summary>
/// 従業員登録サービスインターフェイスの実装
/// </summary>
public class EmployeeRegisterService : IEmployeeRegisterService
{
    /// <summary>
    /// ドメインオブジェクト:従業員のCRUD操作インターフェイス
    /// </summary>
    private readonly IEmployeeRepository _employeeRepository;
    /// <summary>
    /// ドメインオブジェクト:部署のCRUD操作インターフェイス
    /// </summary>
    private readonly IDepartmentRepository _departmentRepository;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="employeeRepository"></param>
    /// <param name="departmentRepository"></param>
    public EmployeeRegisterService(
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// 指定された部署Idの部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns></returns>
    public Department GetById(int id)
    {
        var result = _departmentRepository.FindById(id)!;
        if (result == null)
        {
            throw new NotFoundException($"部署Id{id}に該当する部署は存在しません");
        }
        return result;
    }

    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    /// <returns></returns>
    public List<Department> GetDepartments()
    {
        return _departmentRepository.FindAll();
    }

    /// <summary>
    /// 新しい従業員を登録する
    /// </summary>
    /// <param name="employee"></param>
    public void Register(Employee employee)
    {
        _employeeRepository.Create(employee);
    }
}