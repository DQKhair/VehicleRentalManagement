using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectQLThueXe.Application.Car.Commands;
using ProjectQLThueXe.Application.CarType.Commands;
using ProjectQLThueXe.Application.KCT.Commands;
using ProjectQLThueXe.Application.KT.Commands;
using ProjectQLThueXe.Application.Receipt.Commands;
using ProjectQLThueXe.Domain.Interfaces;
using ProjectQLThueXe.Infrastructure.DBContext;
using ProjectQLThueXe.Infrastructure.Repositories;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Use ReferenceHandler.Preserve
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add authen
var secretKey = builder.Configuration["JWT:SecretKey"] ?? "ykdcesijauessskiudszeakyxfijwwtj";
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,

        //sign token
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

        ClockSkew = TimeSpan.Zero,
    };
});

//add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.AllowAnyOrigin()    
              .AllowAnyHeader()   
              .AllowAnyMethod();
    });
});

// Register the repository
builder.Services.AddScoped<ICarTypeRepository, CarTypeRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IKCTRepository, KCTRepository>();
builder.Services.AddScoped<IKTRepository, KTRepository>();
builder.Services.AddScoped<IReceiptRepository, ReceiptRepository>();
builder.Services.AddScoped<IReceiptDetailRepository, ReceiptDetailRepository>();
builder.Services.AddScoped<IReceiptStatusRepository, ReceiptStatusRepository>();
builder.Services.AddScoped<ICarStatusRepository, CarStatusRepository>();
builder.Services.AddScoped<IHistoryKTRepository, HistoryKTRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

// Add MediatR And FluentValidation
builder.Services.AddMediatR(typeof(CreateCarTypeCommand).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateCarTypeCommandValidator).Assembly);

// Add MyDB 
builder.Services.AddDbContext<MyDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//add wwwroot
app.UseStaticFiles();

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
