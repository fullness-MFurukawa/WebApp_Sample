using Microsoft.AspNetCore.Mvc;
using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Applications.Services;
using WebApp_Sample.Models;
using WebApp_Sample.Utils;
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
    private readonly IFromViewModel<Employee, EmployeeRegisterForm> _employeeViewModelAdapter;
    /// <summary>
    /// TempDataを通じて一時的にデータ(フォームなど)を保存・復元するためのインターフェイス
    /// </summary>
    private readonly  ITempDataStore<EmployeeRegisterForm> _empDataStore;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="employeeRegisterService"></param>
    /// <param name="employeeViewModelAdapter"></param>
    /// <param name="empDataStore"></param>
    public EmployeeRegisterController(
        ILogger<EmployeeRegisterController> logger,
        IEmployeeRegisterService employeeRegisterService,
        IFromViewModel<Employee, EmployeeRegisterForm> employeeViewModelAdapter,
        ITempDataStore<EmployeeRegisterForm> empDataStore)
    {
        _logger = logger;
        _employeeRegisterService = employeeRegisterService;
        _employeeViewModelAdapter = employeeViewModelAdapter;
        _empDataStore = empDataStore;
    }

    /// <summary>
    /// 従業登録(入力)画面表示 アクションメソッド
    /// </summary>
    /// <returns></returns>
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        EmployeeRegisterForm? form = null;
        // TempDataからEmployeeRegisterFormを取得する
        form = _empDataStore.Load(this);
        if (form == null)
        {
            // 従業員登録ViewModelを生成する
            form = new EmployeeRegisterForm();
        }
        // 部署一覧を取得してViewModelに設定する(SelectListItem形式)
        PopulateDepartments(form);
        // formをviewに渡して画面表示する
        return View(form);
    }

    /// <summary>
    ///　入力画面の[完了]ボタンクリックアクションメソッド
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost("Confirm")]
    public IActionResult Confirm(EmployeeRegisterForm form)
    {
        // バリデーションチェック
        if (!ModelState.IsValid) // バリデーションエラーあり
        {
            // 部署一覧を取得してViewModelに設定する(SelectListItem形式)
            PopulateDepartments(form);
            // 入力画面の表示
            return View("Enter", form);
        }
        // 選択された部署のIdで部署データを取得する
        var department = _employeeRegisterService.GetById(form.DeptId ?? 0);
        _logger.LogInformation($"部署Id:{form.DeptId ?? 0}の部署を取得する");
        // ViewModelに部署名を設定する
        form.DeptName = department.Name;
        // 確認画面を表示する
        return View(form);
    }

    /// <summary>
    ///　確認画面の[登録]ボタンクリックアクションメソッド
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost("Regiter")]
    public IActionResult Register(EmployeeRegisterForm form)
    {
        // EmployeeRegisterFormをシリアライズして、TempDataに保存する
        _empDataStore.Save(this, form);
        // 登録処理GETアクションメソッドにリダイレクトする
        return RedirectToAction("Complete");
    }

    /// <summary>
    /// アクションメソッド:Regiter()のリダイレクト先
    /// PRGパターン
    /// </summary>
    /// <returns></returns>
    [HttpGet("Complete")]
    public IActionResult Complete()
    {
        EmployeeRegisterForm? form = null;
        // TempDataからEmployeeRegisterFormを取得する
        form = _empDataStore.Load(this);
        if (form == null)
        {
            // データが存在しない場合、入力画面にリダイレクト
            return RedirectToAction("Enter");
        }
        // EmployeeRegisterFormをドメインモデル:Employeeに変換する
        var employee = _employeeViewModelAdapter.ToDomain(form!);
        // 新しい従業員を登録する
        _employeeRegisterService.Register(employee);
        return View(form);
    }

    /// <summary>
    /// 確認画面の[戻る]ボタンクリックアクションメソッド
    /// </summary>
    /// <returns></returns> 
    [HttpPost("Back")]
    public IActionResult Back(EmployeeRegisterForm form)
    {
        _logger.LogInformation("[戻る]ボタンクリック:{0}", form!.ToString());
        // EmployeeRegisterFormをシリアライズして、TempDataに保存する
        _empDataStore.Save(this, form);
        // 入力画面を出力するアクションメソッドにリダイレクトする
        return RedirectToAction("Enter");
    }

    /// <summary>
    /// 部署一覧を取得してViewModelに設定する(SelectListItem形式)
    /// </summary>
    private void PopulateDepartments(EmployeeRegisterForm form)
    {
        // 従業員登録サービスから部署一覧を取得する
        var departments = _employeeRegisterService.GetDepartments();
        // 部署一覧をEmployeeRegisterFormに登録する
        form.SetDepartments(departments);
        _logger.LogInformation("部署リストを設定");
    }
}