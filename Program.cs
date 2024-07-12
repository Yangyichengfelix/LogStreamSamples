using Mac2sAPI.Configurations;
using Mac2sAPI.Contracts;
using Mac2sAPI.Data;
using Mac2sAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Mac2sAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);
#if ERMO
var connString = builder.Configuration.GetConnectionString("MariaDb");
builder.Services.AddDbContext<Mac2sAPIDbContext>(options => options.UseMySql(connString, new MariaDbServerVersion(new Version(10, 8, 3))));
#endif

var connString = builder.Configuration.GetConnectionString("MariaDb");
//builder.Services.AddDbContext<Mac2sAPIDbContext>(options => options.UseNpgsql(connString));
builder.Services.AddDbContext<Mac2sAPIDbContext>(options => options.UseMySql(connString, new MariaDbServerVersion(new Version(10, 8, 3))));


builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllers(); 


builder.Services.AddIdentityCore<ApiUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<Mac2sAPIDbContext>()
                .AddDefaultTokenProviders();
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
            new string[] {}
        }
    });
});
var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailSender, EmailSender>();


builder.Services.AddSignalR();
builder.Services.AddSingleton<TimerManager>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<IGenerateLogRepository, GenerateLogRepository>();
builder.Services.AddScoped<IActivityReportRepository, ActivityReportRepository>();
builder.Services.AddScoped<IStatusDurationRepository, DurationRepository>();
builder.Services.AddScoped<IStatusGroupDurationRepository, DurationRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();

builder.Services.AddScoped<ISensorPlRepository, SensorValueRepository>();
builder.Services.AddScoped<ISensorGlobalRepository, SensorValueRepository>();
builder.Services.AddScoped<ISensorUniqueRepository, SensorValueRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IGaugeParameterRepository, GaugeParameterRepository>();
builder.Services.AddScoped<IScheduleParameterRepository, ScheduleParameterRepository>();





builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        b => b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{


}
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<SensorS1Hub>("/sensors1hub");



});


app.Run();
