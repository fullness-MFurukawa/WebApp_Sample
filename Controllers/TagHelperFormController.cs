using Microsoft.AspNetCore.Mvc;
/// <summary>
/// タグヘルパーを利用するコントローラ
/// </summary>
[Route("FormSample")]
public class TagHelperFormController : Controller
{
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        // SampleFormを生成する
        var form = new SampleForm();
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
        return View(form);
    }

    [HttpGet("Back")]
    public IActionResult Back(SampleForm form)
    {
        return View("Enter",form);
    }
}