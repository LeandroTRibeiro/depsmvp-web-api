using depsmvp.application.Interfaces.Services;
using depsmvp.application.Mappings;
using DepsMvp.Application.Services;
using depsmvp.insfrastructure.DB;
using depsmvp.insfrastructure.DB.Repositories;
using depsmvp.insfrastructure.ExternalServices;
using depsmvp.insfrastructure.InternalServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IConsultRepository, ConsultRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IPepsRepository, PepsRepository>();
builder.Services.AddScoped<IPepsConsultRepository, PepsConsultRepository>();
builder.Services.AddScoped<ICompanyConsultRepository, CompanyConsultRepository>();

builder.Services.AddScoped<IConsultServices, ConsultServices>();
builder.Services.AddScoped<ICompanyServices, CompanyServices>();
builder.Services.AddScoped<IPepsServices, PepsServiceses>();

builder.Services.AddHttpClient<IBrasilApi, BrasilApi>();
builder.Services.AddHttpClient<IPortalDaTrasparenciaApi, PortalDaTrasparenciaApi>();

builder.Services.AddAutoMapper(typeof(CompanyMapping));
builder.Services.AddAutoMapper(typeof(PepsMapping));

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