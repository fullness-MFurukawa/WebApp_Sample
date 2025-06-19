using WebApp_Sample.Infrastructures.Context;
using WebApp_Sample.Infrastructures.Entities;
using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Applications.Repositories;
using WebApp_Sample.Applications.Adapters;
namespace WebApp_Sample.Infrastructures.Repositories;
/// <summary>
/// ドメインオブジェクト:従業員のCRUD操作インターフェイスの実装
/// </summary>
public class EmployeeRepository : IEmployeeRepository
{
    /// <summary>
    /// アプリケーション用DbContext
    /// </summary>
    private readonly AppDbContext _context;
    /// <summary>
    /// ドメインモデル:従業員と従業員エンティティの相互変換インターフェイスの実装
    /// </summary>
    private readonly IEmployeeAdapter<EmployeeEntity> _adapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context"></param>
    /// <param name="adapter"></param>
    public EmployeeRepository(
        AppDbContext context,
        IEmployeeAdapter<EmployeeEntity> adapter)
    {
        _context = context;
        _adapter = adapter;        
    }

    /// <summary>
    /// 従業員を永続化する
    /// </summary>
    /// <param name="employee">永続化対象の従業員</param>
    public void Create(Employee employee)
    {
        var entity = _adapter.Convert(employee);
        _context.Employees.Add(entity);
        _context.SaveChanges();
    }
}