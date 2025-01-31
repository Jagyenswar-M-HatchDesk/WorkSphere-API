

////using System.Text;
////using Microsoft.AspNetCore.Authentication.JwtBearer;
////using Microsoft.AspNetCore.Identity;
////using Microsoft.EntityFrameworkCore;
////using Microsoft.Extensions.FileProviders;
////using Microsoft.IdentityModel.Tokens;
////using Microsoft.OpenApi.Models;
////using WorkSphere.API.Endpoints;
////using WorkSphere.API.Extension;
////using WorkSphere.Application.Interfaces.IRepo;
////using WorkSphere.Application.Interfaces.IServices;
////using WorkSphere.Application.Services;
////using WorkSphere.Domain;
////using WorkSphere.Infrastructure;
////using WorkSphere.Infrastructure.Repository;

////var builder = WebApplication.CreateBuilder(args);

////// Add services to the container
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();
////builder.Services.AddAntiforgery(options =>
////{
////    options.HeaderName = "X-CSRF-TOKEN"; // Optional: Custom header name
////});



//////builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

//////builder.Services.AddIdentityCore<User>()
//////    .AddEntityFrameworkStores<WorkSphereDbContext>()
//////    .AddDefaultTokenProviders();

////builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
////{
////    options.Password.RequireDigit = true;
////    options.Password.RequiredLength = 8;
////    options.Password.RequireNonAlphanumeric = false;
////    options.Password.RequireUppercase = true;
////    options.Password.RequireLowercase = true;
////})
////.AddEntityFrameworkStores<WorkSphereDbContext>()
////.AddDefaultTokenProviders();
////builder.Services.AddAuthorization();


////builder.Services.AddDbContext<WorkSphereDbContext>(options =>
////    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
////        b => b.MigrationsAssembly("WorkSphere.Infrastructure")));



////builder.Services.AddSwaggerGen(c =>
////{
////    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
////    {
////        In = ParameterLocation.Header,
////        Description = "Please enter JWT with Bearer into field",
////        Name = "Authorization",
////        Type = SecuritySchemeType.Http,
////        BearerFormat = "JWT",
////        Scheme = "Bearer"
////    });
////    c.AddSecurityRequirement(new OpenApiSecurityRequirement
////    {
////        {
////            new OpenApiSecurityScheme
////            {
////                Reference = new OpenApiReference
////                {
////                    Type = ReferenceType.SecurityScheme,
////                    Id = "Bearer"
////                }
////            },
////            new string[] { }
////        }
////    });
////});
////var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);
////builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
////{
////    options.Authority = "https://localhost:7104/";
////    options.TokenValidationParameters = new TokenValidationParameters
////    {
////        ValidateIssuer = true,
////        ValidateAudience = true,
////        ValidateLifetime = true,
////        ValidateIssuerSigningKey = true,
////        ValidIssuer = builder.Configuration["Jwt:Issuer"],
////        ValidAudience = builder.Configuration["Jwt:Audience"],
////        IssuerSigningKey = new SymmetricSecurityKey(key)
////    };
////});




////builder.Services.AddCors(options =>
////{
////    options.AddPolicy("AllowSpecificOrigin", policy =>
////    {
////        policy.WithOrigins("http://localhost:3000") // React app ka origin
////              .AllowAnyHeader()
////              .AllowAnyMethod()
////              .AllowCredentials(); // Cookies ke liye zaroori hai
////    });
////});





////builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
////builder.Services.AddScoped<IProjectService, ProjectServices>();
////builder.Services.AddScoped<ITaskRepo, TaskRepo>();
////builder.Services.AddScoped<ITaskService, TaskServices>();
////builder.Services.AddScoped<IClientRepo, ClientFRepo>();
////builder.Services.AddScoped<IClientServices, ClientService>();
////builder.Services.AddScoped<IAccountRepo, AccountRepo>();
////builder.Services.AddScoped<IEmployeeService, EmployeeService>();
////builder.Services.AddScoped<IEmployeeRepo, EmployeeRepository>();
////builder.Services.AddScoped<IAccountService, AccountServices>();
////builder.Services.AddScoped<IEmailService, EmailService>();

////var app = builder.Build();

////// Configure the HTTP request pipeline
////if (app.Environment.IsDevelopment())
////{
////    app.UseDeveloperExceptionPage();
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseStaticFiles(new StaticFileOptions
////{
////    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Uploads"))
////});

////app.UseCors("AllowSpecificOrigin");

////app.UseHttpsRedirection();
////app.UseAuthentication();
////app.UseAuthorization();
////app.UseAntiforgery();

//////app.MapIdentityApi<User>();
////app.Register_LoginEndpoint();
////app.Projects_Endpoints();
////app.Task_EndPoints();
////app.DepartmentEndpoint();
////app.Client_Endpoints();
////app.Manager_Endpoints();
////app.Severity_Endponits();
////app.MapEmployeeEndpoints();

////app.Run();


//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.FileProviders;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using System.Text;
//using WorkSphere.API.Endpoints;
//using WorkSphere.Application.Interfaces.IRepo;
//using WorkSphere.Application.Interfaces.IServices;
//using WorkSphere.Application.Services;
//using WorkSphere.Domain;
//using WorkSphere.Infrastructure.Repository;
//using WorkSphere.Infrastructure;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddAntiforgery(options =>
//{
//    options.HeaderName = "X-CSRF-TOKEN"; // Optional: Custom header name
//});

//// **Remove cookie authentication** as we're using JWT
////builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
////    .AddCookie(options => 
////    {
////        options.LoginPath = "/account/login"; 
////    });

//// Add Identity and configure it
//builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
//{
//    options.Password.RequireDigit = true;
//    options.Password.RequiredLength = 8;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireLowercase = true;
//})
//.AddEntityFrameworkStores<WorkSphereDbContext>()
//.AddDefaultTokenProviders();

//// JWT Authentication
//var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);
//builder.Services.AddAuthentication(option =>
//{
//    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme.ToString();
//}).AddJwtBearer(options =>
//{

//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = false,
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Audience"],

//    };
//});

//builder.Services.AddAuthorization();

//builder.Services.AddDbContext<WorkSphereDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
//        b => b.MigrationsAssembly("WorkSphere.Infrastructure")));

//// Swagger & CORS configuration
//builder.Services.AddSwaggerGen(c =>
//{
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Please enter JWT with Bearer into field",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        BearerFormat = "JWT",
//        Scheme = "Bearer"
//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                }
//            },
//            new string[] { }
//        }
//    });
//});

//// CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin", policy =>
//    {
//        policy.WithOrigins("http://localhost:3000") 
//              .AllowAnyHeader()
//              .AllowAnyMethod()
//              .AllowCredentials();
//    });
//});

//builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
//builder.Services.AddScoped<IProjectService, ProjectServices>();
//builder.Services.AddScoped<ITaskRepo, TaskRepo>();
//builder.Services.AddScoped<ITaskService, TaskServices>();
//builder.Services.AddScoped<IClientRepo, ClientFRepo>();
//builder.Services.AddScoped<IClientServices, ClientService>();
//builder.Services.AddScoped<IAccountRepo, AccountRepo>();
//builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//builder.Services.AddScoped<IEmployeeRepo, EmployeeRepository>();
//builder.Services.AddScoped<IAccountService, AccountServices>();
//builder.Services.AddScoped<IEmailService, EmailService>();

//var app = builder.Build();

//// Middleware configuration
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Uploads"))
//});

//app.UseCors("AllowSpecificOrigin");

//app.UseHttpsRedirection();
//app.UseAuthentication();  // Authentication ko enable karna
//app.UseAuthorization();   // Authorization ko enable karna
//app.UseAntiforgery();

//app.Register_LoginEndpoint();
//app.Projects_Endpoints();
//app.Task_EndPoints();
//app.DepartmentEndpoint();
//app.Client_Endpoints();
//app.Manager_Endpoints();
//app.Severity_Endponits();
//app.MapEmployeeEndpoints();

//app.Run();



using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WorkSphere.API.Endpoints;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Application.Services;
using WorkSphere.Domain;
using WorkSphere.Infrastructure.Repository;
using WorkSphere.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN"; // Optional: Custom header name
});

// Add Identity and configure it
builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
})
.AddEntityFrameworkStores<WorkSphereDbContext>()
.AddDefaultTokenProviders();

// JWT Authentication
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme.ToString();
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
    };
});

builder.Services.AddAuthorization();

builder.Services.AddDbContext<WorkSphereDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("WorkSphere.Infrastructure")));

// Swagger & CORS configuration
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<IProjectService, ProjectServices>();
builder.Services.AddScoped<ITaskRepo, TaskRepo>();
builder.Services.AddScoped<ITaskService, TaskServices>();
builder.Services.AddScoped<IClientRepo, ClientFRepo>();
builder.Services.AddScoped<IClientServices, ClientService>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepository>();
builder.Services.AddScoped<IAccountService, AccountServices>();
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Middleware configuration
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Serve React static files from the build folder
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "build")),
    RequestPath = "/static"  // Optional: Agar aapko custom path set karna ho toh
});

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();
app.UseAuthentication();  // Authentication ko enable karna
app.UseAuthorization();   // Authorization ko enable karna
app.UseAntiforgery();

// Endpoints
app.Register_LoginEndpoint();
app.Projects_Endpoints();
app.Task_EndPoints();
app.DepartmentEndpoint();
app.Client_Endpoints();
app.Manager_Endpoints();
app.Severity_Endponits();
app.MapEmployeeEndpoints();

// Fallback to React's index.html for routing
app.MapFallbackToFile("index.html");

app.Run();
