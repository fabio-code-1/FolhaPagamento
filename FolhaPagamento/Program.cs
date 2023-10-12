using FolhaPagamento.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicione os servi�os ao container.
builder.Services.AddControllersWithViews();

// Configure o contexto do banco de dados
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer("Data Source=FABIO;Initial Catalog=FolhaPagamento;Integrated Security=True; Encrypt=False"));

builder.Services.AddAuthentication("MyCookieAuthenticationScheme")
    .AddCookie("MyCookieAuthenticationScheme", options =>
    {
        options.LoginPath = "/Account/Login"; // Defina o caminho da p�gina de login
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireLoggedIn", policy => policy.RequireAuthenticatedUser());
});

var app = builder.Build();

// Configure o pipeline de solicita��es HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padr�o de HSTS � de 30 dias. Voc� pode querer alterar isso para cen�rios de produ��o, consulte https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Middleware de autentica��o
app.UseAuthorization();  // Middleware de autoriza��o

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
