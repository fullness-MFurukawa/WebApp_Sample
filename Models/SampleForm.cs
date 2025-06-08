using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
/// <summary>
/// リスト3-3 
/// フォームデータを保持するViewModel
/// </summary>
public class SampleForm
{
    /// <summary>
    /// 氏名プロパティ
    /// </summary>
    /// <value></value>
    [Display(Name = "氏名")]
    public string? Name { get; set; }
    /// <summary>
    /// 年齢プロパティ
    /// </summary>
    /// <value></value>
    [Display(Name = "年齢")]
    public int Age { get; set; }

   
   
   
    /// <summary>
    /// 選択された結果を格納するプロパティ
    /// </summary>
    [Display(Name = "都道府県")]
    public int PrefecturesId { get; set; }
    /// <summary>
    /// プルダウン表示するリスト
    /// </summary>
    /// <value></value>
    public List<SelectListItem> PrefecturesList { get; set; } = new List<SelectListItem>
    {
        new SelectListItem{ Text="--選択されていません--", Value="0" , Selected = true },
        new SelectListItem{ Text= "北海道", Value= "1" },
        new SelectListItem{ Text= "青森県", Value= "2" },
        new SelectListItem{ Text= "岩手県", Value= "3" },
    };
}