namespace WebApp_Sample.Exceptions;
/// <summary>
/// 検索したデータが見つからないことを表す例外クラス
/// </summary>
public class NotFoundException : Exception
{
    public NotFoundException() { }
    public NotFoundException(string message) 
    : base(message) { }
    
    public NotFoundException(string message, Exception innerException)
    : base(message, innerException) { }
}