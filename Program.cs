using Microsoft.EntityFrameworkCore;
using SElab5.Data;
using SElab5.Repositories;
using SElab5.Repositories.Interfaces;
using SElab5.Services;
using SElab5.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IHearingService, HearingService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IUserService, UserService>();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IHearingRepository, HearingRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// Session
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();