using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectQLThueXe.Application.Car.Commands;
using ProjectQLThueXe.Application.CarType.Commands;
using ProjectQLThueXe.Application.KCT.Commands;
using ProjectQLThueXe.Application.KT.Commands;
using ProjectQLThueXe.Application.Receipt.Commands;
using ProjectQLThueXe.Domain.Interfaces;
using ProjectQLThueXe.Infrastructure.DBContext;
using ProjectQLThueXe.Infrastructure.Repositories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Use ReferenceHandler.Preserve
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Add MediatR And FluentValidation CarType
builder.Services.AddMediatR(typeof(CreateCarTypeCommand).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateCarTypeCommandValidator).Assembly);
// Add MediatR And FluentValidation Car
builder.Services.AddMediatR(typeof(CreateCarCommand).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateCarCommandValidator).Assembly);
// Add MediatR And FluentValidation KCT
builder.Services.AddMediatR(typeof(CreateKCTCommand).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateKCTCommnadValidator).Assembly);
// Add MediatR And FluentValidation KCT
builder.Services.AddMediatR(typeof(CreateKTCommand).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateKTCommnadValidator).Assembly);
// Add MediatR And FluentValidation KCT
builder.Services.AddMediatR(typeof(CreateReceiptCommand).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateReceiptCommandValidator).Assembly);
// Add MediatR And FluentValidation Receipt
builder.Services.AddMediatR(typeof(CreateReceiptCommand).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof (CreateReceiptCommandValidator).Assembly);


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

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
