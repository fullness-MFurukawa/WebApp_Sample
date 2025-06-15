using Microsoft.AspNetCore.Mvc;
using WebApp_Sample.Infrastructures.Context;
namespace WebApp_Sample.Controllers;
public class EmployeeController : Controller
{
    
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }


    public IActionResult Index(){
        var results = _context.Employees.ToList();
          // 文字列に整形（改行あり）
        var text = string.Join(Environment.NewLine, results.Select(emp =>
            $"ID: {emp.EmpId}, 名前: {emp.EmpName}, 部署ID: {emp.DeptId}"
        ));
        // text/plain でブラウザに表示
        return Content(text, "text/plain; charset=utf-8");
    }
}