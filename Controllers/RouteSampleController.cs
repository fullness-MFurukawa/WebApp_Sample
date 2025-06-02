using Microsoft.AspNetCore.Mvc;

namespace WebApp_Sample.Controllers;
/// <summary>
/// ルーティング属性を使用しない
/// </summary>
public class RouteSampleController : Controller
{
    /// <summary>
    /// デフォルトアクション
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return Content("/RouteSample または /RouteSample/Index");
    }

    /// <summary>
    /// SampleContentアクション
    /// </summary>
    /// <returns></returns>
    public IActionResult SampleContent()
    {
        return Content("/RouteSample/SampleContent");
    }
}