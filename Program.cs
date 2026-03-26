using Microsoft.EntityFrameworkCore;
using api.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using api.Validators;
using api.Interfaces;
using api.Services;
using api.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePaymentRequestDtoValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
builder.Services.AddValidatorsFromAssemblyContaining<CreatePaymentRequestDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdatePaymentRequestDtoValidator>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

