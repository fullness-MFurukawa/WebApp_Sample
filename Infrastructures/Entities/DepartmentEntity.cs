namespace WebApp_Sample.Infrastructures.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// 部署テーブル(department)を扱うEntity Framework Coreのエンティティクラス
/// </summary>
[Table("department")]
public class DepartmentEntity 
{
    [Key] 
    [Column("dept_id")]
    public int DeptId { get; set; }
    [Column("dept_name")]
    public string DeptName { get; set; } = string.Empty; 
}