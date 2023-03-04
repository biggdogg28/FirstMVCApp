using FirstMVCApp.DataContext;
using FirstMVCApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// AddTransient vs AddScoped vs AddSingleton
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProgrammingClubDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddTransient<ProgrammingClubDataContext, ProgrammingClubDataContext>();
builder.Services.AddTransient<AnnouncementsRepository, AnnouncementsRepository>();
builder.Services.AddTransient<MembersRepository, MembersRepository>();
builder.Services.AddTransient<MembershipTypesRespository, MembershipTypesRespository>();
builder.Services.AddTransient<CodeSnippetsRepository, CodeSnippetsRepository>();
builder.Services.AddTransient<MembershipsRepository, MembershipsRepository>();

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
