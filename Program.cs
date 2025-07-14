using blog.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllersWithViews();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityApi<User>();
app.MapControllers();

app.Run();
