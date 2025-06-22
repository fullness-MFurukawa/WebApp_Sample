using Microsoft.AspNetCore.Mvc;
namespace WebApp_Sample.Models.Stores;
/// <summary>
/// TempDataを通じて一時的にデータ(フォームなど)を保存・復元するためのインターフェイス
/// </summary>
/// <typeparam name="T">TempDataに保存・復元するオブジェクトの型</typeparam>
public interface ITempDataStore<T> where T : class
{
    /// <summary>
    /// 指定されたコントローラのTempDataに、オブジェクトをJSONとして保存する
    /// </summary>
    /// <param name="controller">TempDataを持つコントローラ</param>
    /// <param name="model">保存するオブジェクト</param>
    void Save(Controller controller, T model);

    /// <summary>
    /// TempDataに保存されたJSONを復元して、指定した型のオブジェクトを返す
    /// </summary>
    /// <param name="controller">TempDataを持つコントローラ</param>
    /// <returns>復元されたオブジェクト、存在しない場合や復元に失敗した場合はnull</returns>
    T? Load(Controller controller);
}