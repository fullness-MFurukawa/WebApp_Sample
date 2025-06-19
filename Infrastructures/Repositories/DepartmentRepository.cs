using WebApp_Sample.Infrastructures.Context;
using WebApp_Sample.Infrastructures.Entities;
using WebApp_Sample.Applications.Domains.Departments;

namespace WebApp_Sample.Infrastructures.Repositories;
/// <summary>
/// ドメインオブジェクト:部署のCRUD操作インターフェイス実装
/// </summary>
public class DepartmentRepository : IDepartmentRepository
{
    /// <summary>
    /// アプリケーション用DbContext
    /// </summary>
    private readonly AppDbContext _context;
    /// <summary>
    /// ドメインモデル:部署と部署エンティティの相互変換インターフェイスの実装
    /// </summary>
    private readonly IDepartmentAdapter<DepartmentEntity> _adapter;
    public DepartmentRepository(
        AppDbContext context,
        IDepartmentAdapter<DepartmentEntity> adapter)
    {
            _context = context;
            _adapter = adapter;
    }

    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    /// <returns>部署のリスト</returns>
    public List<Department> FindAll()
    {
        var entities = _context.Departments.ToList();
        var results = new List<Department>();
        foreach (var entity in entities)
        {
            results.Add(_adapter.Restore(entity));
        }   
        return results;
    }

    /// <summary>
    /// 指定された部署Idの部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns>取得して部署</returns>
    public Department? FindById(int id)
    {
        var result = _context.Departments.FirstOrDefault(d => d.DeptId == id);
        if (result == null)
        {
            return null;
        }
        return _adapter.Restore(result);
    }
}