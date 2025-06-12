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
        // TempDataからSampleFormを取り出す
        string json = (string) TempData["SampleForm"]!;
        SampleForm? form = null;
        if (json == null)
        {
            // TempDataにSampleFormが存在しない場合は生成する
            form = new SampleForm();
        }
        else
        {
            // 存在する場合は、SampleFormをデシリアライズする
            form = JsonSerializer.Deserialize<SampleForm>(json);
        }
        // Enter.cshtmlにSampleFormを渡す
        return View(form);
    }

    /// <summary>
    /// [送信]ボタンクリックに対するアクション
    /// </summary>
    /// <param name="form">入力された値を保持するSampleForm</param>
    /// <returns></returns>
    [HttpPost("Result")]
    public IActionResult Result(SampleForm form)
    {
        // バリデーションチェック
        if (!ModelState.IsValid)
        {
            // SampleFormをシリアライズする
            var json = JsonSerializer.Serialize(form);
            // TempDataにjsonを追加する
            TempData["SampleForm"] = json;
            // 入力画面にリダイレクトする
            return RedirectToAction("Enter");
        }
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