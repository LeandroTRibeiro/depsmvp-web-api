using depsmvp.application.Mappings;
using DepsMvp.Application.Services;
using depsmvp.insfrastructure.ExternalServices;
using depsmvp.insfrastructure.InternalServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICompanyService, CompanyServices>();
builder.Services.AddSingleton<IBrasilApi, BrasilApi>();

builder.Services.AddAutoMapper(typeof(CompanyMapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();