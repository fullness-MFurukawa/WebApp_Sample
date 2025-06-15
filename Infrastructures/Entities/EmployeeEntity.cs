namespace WebApp_Sample.Infrastructures.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// 従業員テーブル(employee)を扱うEntity Framework Coreのエンティティクラス
/// </summary>
[Table("employee")]
public class EmployeeEntity{
    [Key] 
    [Column("emp_id")]
    public int EmpId { get; set; }
    [Column("emp_name")]
    public string EmpName { get; set; } = string.Empty;
    [Column("dept_id")]
    public int? DeptId { get; set; }
}