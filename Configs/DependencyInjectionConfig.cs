using Microsoft.EntityFrameworkCore;
using WebApp_Sample.Applications.Domains;
using WebApp_Sample.Applications.Services;
using WebApp_Sample.Applications.Services.Impls;
using WebApp_Sample.Applications.Repositories;
using WebApp_Sample.Applications.Adapters;
using WebApp_Sample.Infrastructures.Adapters;
using WebApp_Sample.Infrastructures.Context;
using WebApp_Sample.Infrastructures.Entities;
using WebApp_Sample.Infrastructures.Repositories;
using WebApp_Sample.Models;
using WebApp_Sample.Models.Adapters.Impls;
using WebApp_Sample.Utils;

namespace WebApp_Sample.Configs;
/// <summary>
/// 依存定義および依存性注入ユーティリティクラス
/// </summary>
public static class DependencyInjectionConfig
{
    /// <summary>
    /// アプリケーション全体の依存定義の設定
    /// </summary>
    /// <param name="configuration">アプリケーション環境</param>
    /// <param name="services">DIコンテナ</param>
    public static void SettingDependencyInjection(IConfiguration configuration, IServiceCollection services)
    {
        // EntityFramework Coreのインスタンス生成と依存定義
        SettingEntityFrameworkCore(configuration, services);
        // インフラストラクチャ層のインスタンス生成と依存定義
        SettingInfrastructures(services);
        // アプリケーション層のインスタンス生成と依存定義
        SettingApplications(services);
        // プレゼンテーション層のインスタンス生成と依存定義
        SettingPresentations(services);
    }

    /// <summary>
    /// EntityFramework Coreのインスタンス生成と依存定義
    /// </summary>
    /// <param name="configuration">アプリケーション環境</param>
    /// <param name="services">DIコンテナ</param>
    private static void SettingEntityFrameworkCore(IConfiguration configuration, IServiceCollection services)
    {
        // 接続文字列（appsettings.json）から取得
        var connectionString = configuration.GetConnectionString("MySqlConnection");
        // DbContext登録（Pomelo用）
        services.AddDbContext<AppDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
  
    /// <summary>
    /// インフラストラクチャ層のインスタンス生成と依存定義
    /// </summary>
    /// <param name="services">DIコンテナ</param>
    private static void SettingInfrastructures(IServiceCollection services)
    {
        // ドメインモデル:部署と部署エンティティの相互変換インターフェイスの実装
        services.AddScoped<IDepartmentAdapter<DepartmentEntity>, DepartmentEntityAdapter>();
        // ドメインモデル:従業員と従業員エンティティの相互変換インターフェイスの実装
        services.AddScoped<IEmployeeAdapter<EmployeeEntity>, EmployeeEntityAdapter>();
        // ドメインオブジェクト:部署のCRUD操作インターフェイス実装
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        // ドメインオブジェクト:従業員のCRUD操作インターフェイスの実装
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }

    /// <summary>
    /// アプリケーション層のインスタンス生成と依存定義
    /// </summary>
    /// <param name="services">DIコンテナ</param>
    private static void SettingApplications(IServiceCollection services)
    {
        // 従業員登録サービスインターフェイスの実装
        services.AddScoped<IEmployeeRegisterService, EmployeeRegisterService>();
    }

    /// <summary>
    /// プレゼンテーション層のインスタンス生成と依存定義
    /// </summary>
    /// <param name="services">DIコンテナ</param>
    private static void SettingPresentations(IServiceCollection services)
    {
        // 従業員登録ViewModelをドメインオブジェクト:従業員に変換するアダプターインターフェイスの実装
        services.AddScoped<IFromViewModel<Employee, EmployeeRegisterForm> ,
            EmployeeRegisterViewModelAdapter>();
        // TempDataへのEmployeeRegisterFormの保存・復元するためのインターフェイス実装
        services.AddScoped<ITempDataStore<EmployeeRegisterForm> ,
            EmployeeRegisterFormStore>();
    }
}