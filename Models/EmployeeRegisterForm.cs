using System.ComponentModel.DataAnnotations;

namespace WebApp_Sample.Models;
/// <summary>
/// 部署登録ViewModelクラス
/// </summary>
public class EmployeeRegisterForm
{
    /// <summary>
    /// 氏名
    /// </summary>
    /// <value></value>
    [Display(Name = "氏名")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    public string? Name { get; set; } = string.Empty;
    /// <summary>
    /// 所属部署
    /// </summary>
    /// <value></value>
    [Display(Name = "所属部署")]
    [Required(ErrorMessage = "{0}は選択必須です。")]
    public int? DeptId { get; set; } = 0;
}