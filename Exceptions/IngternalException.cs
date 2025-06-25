namespace WebApp_Sample.Exceptions;
/// <summary>
/// システム内部エラーを表す例外クラス
/// (データベースの不正操作や停止など)
public class InternalException : Exception
{
    public InternalException(string message) : base() { }
    public InternalException(string message, Exception innerException) : base(message, innerException) { }
}