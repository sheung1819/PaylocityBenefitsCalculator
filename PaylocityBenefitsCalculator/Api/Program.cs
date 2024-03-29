using Api.Processor;
using Api.Repositories;
using Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Employee Benefit Cost Calculation Api",
        Description = "Api to support employee benefit cost calculations"
    });
});

var allowLocalhost = "allow localhost";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowLocalhost,
        policy => { policy.WithOrigins("http://localhost:3000", "http://localhost"); });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IDependentService, DependentService>();
builder.Services.AddTransient<IPaycheckService, PaycheckService>();
builder.Services.AddTransient<IBenefitService, BenefitService>();
builder.Services.AddTransient<IMonthlyPaycheckCalculator, MonthlyPaycheckCalculator>();
builder.Services.AddTransient<IDependentQualifyService, DependentQualifyService>();
//builder.Services.AddKeyedTransient<IProcessorFactory, EmployeeBenefitProcessorFactory>("EmployeeProcessor");
//builder.Services.AddKeyedTransient<IProcessorFactory, DependentBenefitProcessorFactory>("DependentProcessor");
builder.Services.AddTransient<IProcessorFactory, EmployeeBenefitProcessorFactory>();
builder.Services.AddTransient<IProcessorFactory, DependentBenefitProcessorFactory>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowLocalhost);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
