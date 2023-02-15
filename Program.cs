using MySql.Data.MySqlClient;
using PokemonRoster.Client;
using PokemonRoster.Data;
using System.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("pokeroster");
 
builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new MySqlConnection(connection);
    
    conn.Open();
    return conn;
});

builder.Services.AddTransient<IPokeRepository, PokeRepository>();

builder.Services.AddTransient<IPokeClient,PokeClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
