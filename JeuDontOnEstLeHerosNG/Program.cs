using JeuDontOnEstLeHeros.Core.BackOffice.Web.UI.Helpers;
using JeuDontOnEstLeHerosNG.Infra.Database;
using JeuDontOnEstLeHerosNG.Infra.Database.Repositories;
using JeuDontOnEstLeHerosNG.Web.Constraints;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(AutoMapperProfile.GetInstance());

builder.Services.AddDbContext<AventureDataContext>(options => options.UseSqlServer());
builder.Services.AddDbContext<IdentityDataContext>(options => options.UseSqlServer());

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityDataContext>();

builder.Services.AddScoped<IAventureRepository, AventureRepository>();
builder.Services.AddScoped<IParagrapheRepository, ParagrapheRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IReponseRepository, ReponseRepository>();

builder.Services.AddAuthentication().AddGoogle(options =>
{
    options.ClientId = "932751390909-kt4c4icbtphgam08a578i6ud7gdnap2s.apps.googleusercontent.com";
    options.ClientSecret = "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";
});
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

//app.UseSession().UseCookiePolicy(options: new CookiePolicyOptions { HttpOnly = HttpOnlyPolicy.Always });

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "editparaf",
    pattern: "edition-paragraphe/{id}",
    defaults: new { Controller = "Paragraphe", Action = "Edit" },
    //constraints: new { id = @"\d+" }
    constraints: new { id = new LogConstraints() });

app.MapControllerRoute(
    name: "aventure-creation",
    pattern: "demarrer-une-nouvelle-aventure",
    defaults: new { Controller = "Aventure", Action = "Create" });

app.MapControllerRoute(
    name: "aventure-edition",
    pattern: "editer-une-nouvelle-aventure",
    defaults: new { Controller = "Aventure", Action = "Edit" },
    constraints: new { id = @"\d+" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
