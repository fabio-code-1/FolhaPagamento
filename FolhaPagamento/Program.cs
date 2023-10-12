using FolhaPagamento.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicione os serviços ao container.
builder.Services.AddControllersWithViews();

// Configure o contexto do banco de dados
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer("Data Source=FABIO;Initial Catalog=FolhaPagamento;Integrated Security=True; Encrypt=False"));

builder.Services.AddAuthentication("MyCookieAuthenticationScheme")
    .AddCookie("MyCookieAuthenticationScheme", options =>
    {
        options.LoginPath = "/Account/Login"; // Defina o caminho da página de login
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireLoggedIn", policy => policy.RequireAuthenticatedUser());
});

var app = builder.Build();

// Configure o pipeline de solicitações HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padrão de HSTS é de 30 dias. Você pode querer alterar isso para cenários de produção, consulte https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Middleware de autenticação
app.UseAuthorization();  // Middleware de autorização

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
