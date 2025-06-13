using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
/// <summary>
/// タグヘルパーを利用するコントローラ
/// </summary>
[Route("FormSample")]
public class TagHelperFormController : Controller
{
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        var form = new SampleForm();
        // Enter.cshtmlにSampleFormを渡す
        return View(form);
    }

    /// <summary>
    /// [送信]ボタンクリックに対するアクション
    /// </summary>
    /// <param name="form">入力された値を保持するSampleForm</param>
    /// <returns></returns>
    [HttpPost("Calc")]
    public IActionResult Calc(SampleForm form)
    {
        // バリデーションチェック
        if (!ModelState.IsValid)
        {
            // バリデーションエラーの場合は入力画面を表示する
            return View("Enter", form);
        }
        // SampleFormをシリアライズする
        var json = JsonSerializer.Serialize(form);
        // TempDataにjsonを追加する
        TempData["SampleForm"] = json;
        // 入力画面にリダイレクトする
        return RedirectToAction("Result");
    }

    public IActionResult Result()
    {
        // TempDataからSampleFormを取得する
        string json = (string)TempData["SampleForm"]!;
        // SampleFormをデシリアライズする
        var form = JsonSerializer.Deserialize<SampleForm>(json);
        // 結果画面を表示する
        return View(form);
    }

    /// <summary>
    /// [戻る]ボタンクリックに対するアクション
    /// </summary>
    /// <returns></returns>
    [HttpGet("Back")]
    public IActionResult Back()
    {
        // 入力画面を出力するアクションメソッドにリダイレクトする
        return RedirectToAction("Enter");
    }
}