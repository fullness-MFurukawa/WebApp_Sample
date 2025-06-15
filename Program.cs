using WebApp_Sample.Configs;

var builder = WebApplication.CreateBuilder(args);

// 🔽 セッションの前提：分散キャッシュの設定
builder.Services.AddDistributedMemoryCache();

// 🔽 セッションの設定（Cookie＋Timeoutなど）
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// Add services to the container.
builder.Services.AddControllersWithViews();

// 依存定義および依存性注入ユーティリティクラス 
// アプリケーションの依存関係を構築
DependencyInjectionConfig.SettingDependencyInjection(builder.Configuration, builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// セッションサービスを追加する
//builder.Services.AddSession();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// セッションをミドルウェアとして有効化
app.UseSession();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
