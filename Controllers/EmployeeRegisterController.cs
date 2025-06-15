using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Applications.In;
using WebApp_Sample.Models;
namespace WebApp_Sample.Controllers;
/// <summary>
/// 従業員登録コントローラ
/// </summary>
[Route("EmployeeRegister")]
public class EmployeeRegisterController : Controller
{
    /// <summary>
    /// ロガー
    /// </summary>
    private readonly ILogger<EmployeeRegisterController> _logger;
    /// <summary>
    /// 従業員登録サービスインターフェイス
    /// </summary>
    private readonly IEmployeeRegisterService _employeeRegisterService;
    /// <summary>
    /// 従業員登録ViewModelをドメインオブジェクト:従業員に変換するアダプターインターフェイス
    /// </summary>
    private readonly IEmployeeViewModelAdapter<EmployeeRegisterForm> _employeeViewModelAdapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="employeeRegisterService"></param>
    /// <param name="employeeViewModelAdapter"></param>
    public EmployeeRegisterController(
        ILogger<EmployeeRegisterController> logger,
        IEmployeeRegisterService employeeRegisterService,
        IEmployeeViewModelAdapter<EmployeeRegisterForm> employeeViewModelAdapter)
    {
        _logger = logger;
        _employeeRegisterService = employeeRegisterService;
        _employeeViewModelAdapter = employeeViewModelAdapter;
    }

    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        // 従業員登録ViewModelを生成する
        var form = new EmployeeRegisterForm();
        // Sessionからdepartmentsで登録された部署のリストを取得する
        var json = HttpContext.Session.GetString("departments");
        if (string.IsNullOrEmpty(json)) // 存在しない
        {
            // 従業員登録サービスに部署リスト取得を依頼する
            var departments = _employeeRegisterService.GetDepartments();
            // 従業員登録ViewModelのプロパティに設定する
            form.SetDepartments(departments);
            // 部署のリストをシリアライズする
            var jsonData = JsonSerializer.Serialize(departments);
            // Sessionに部署のリストを格納する
            HttpContext.Session.SetString("departments", jsonData);

            _logger.LogInformation("Sessionに部署のリストが無いので、取得してSessionに格納後、従業員登録ViewModelに設定");
        }
        else // 存在する
        {
            // JSON文字列をデシリアライズする
            var departments = JsonSerializer.Deserialize<List<Department>>(json);
            // 従業員登録ViewModelのプロパティに設定する
            form.SetDepartments(departments!);

            _logger.LogInformation("Sessionに部署のリストが存在するので、デシリアライズして従業員登録ViewModelに設定");
        }
        // formをviewに渡して画面表示する
        return View(form);
    }
}