internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(60);
        });
        builder.Services.AddHttpContextAccessor();
        var app = builder.Build();
        app.UseStaticFiles();
        //app.MapGet("/", () => "Hello World!");
        app.UseSession();

        app.MapControllerRoute(
            name: "default",
            pattern: "/{controller=Home}/{action=Home}"
            );
        app.MapControllerRoute(
          name: "login",
          pattern: "{controller}/{action}/{para1}/{para2}"
           );

        app.MapControllerRoute(
            name: "default",
            pattern: "/{controller=Product}/{action=Update}"
            );

       app.Run();
    }
}