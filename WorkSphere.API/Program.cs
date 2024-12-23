//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using WorkSphere.API.Endpoints;
//using WorkSphere.API.Endpoints.Admin;
//using WorkSphere.API.Extension;
//using WorkSphere.Application.Interfaces.IRepo;
//using WorkSphere.Application.Interfaces.IServices;
//using WorkSphere.Application.Services;
//using WorkSphere.Domain;
//using WorkSphere.Infrastructure;
//using WorkSphere.Infrastructure.Repository;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
//    //.AddBearerToken(IdentityConstants.BearerScheme);

//builder.Services.AddIdentityCore<User>()
//    .AddEntityFrameworkStores<WorkSphereDbContext>()
//    .AddApiEndpoints();

//builder.Services.AddDbContext<WorkSphereDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
//     b => b.MigrationsAssembly("WorkSphere.Infrastructure")));
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});
//builder.Services.AddIdentityCore<User>()
//    .AddRoles<IdentityRole<int>>()
//    .AddEntityFrameworkStores<WorkSphereDbContext>()
//    .AddSignInManager()
//    .AddDefaultTokenProviders();

//builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
//builder.Services.AddScoped<IProjectService, ProjectServices>();
//builder.Services.AddScoped<ITaskRepo, TaskRepo>();
//builder.Services.AddScoped<ITaskService, TaskServices>();





//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();

//    //app.ApplyMigration();
//}

//app.UseCors("AllowAll");
//app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();


//app.MapIdentityApi<User>();
//app.Register_LoginEndpoint();
//app.Projects_Endpoints();
//app.Task_EndPoints();


//app.Run();

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorkSphere.API.Endpoints;
using WorkSphere.API.Endpoints.Admin;
using WorkSphere.API.Extension;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Application.Services;
using WorkSphere.Domain;
using WorkSphere.Infrastructure;
using WorkSphere.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<WorkSphereDbContext>()
    .AddApiEndpoints();

builder.Services.AddDbContext<WorkSphereDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("WorkSphere.Infrastructure")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React app ka origin
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Cookies ke liye zaroori hai
    });
});


builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<WorkSphereDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true; // Cross-site attacks prevent karega
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // HTTPS ke liye
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Cookie expiration time
    options.SlidingExpiration = true; // Auto-renew cookies
    options.Cookie.SameSite = SameSiteMode.None; // Required for cross-origin
});


builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<IProjectService, ProjectServices>();
builder.Services.AddScoped<ITaskRepo, TaskRepo>();
builder.Services.AddScoped<ITaskService, TaskServices>();
builder.Services.AddScoped<IClientRepo, ClientFRepo>();
builder.Services.AddScoped<IClientServices, ClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityApi<User>();
app.Register_LoginEndpoint();
app.Projects_Endpoints();
app.Task_EndPoints();
app.DepartmentEndpoint();
app.Client_Endpoints();
app.Manager_Endpoints();
app.Severity_Endponits();

app.Run();