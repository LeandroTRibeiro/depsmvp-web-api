using depsmvp.application.Interfaces.Services;
using depsmvp.application.Mappings;
using DepsMvp.Application.Services;
using depsmvp.insfrastructure.DB;
using depsmvp.insfrastructure.DB.Repositories;
using depsmvp.insfrastructure.ExternalServices;
using depsmvp.insfrastructure.InternalServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        build =>
            build.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
});

builder.Services.AddScoped<IConsultRepository, ConsultationRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IPepsRepository, PepsRepository>();
builder.Services.AddScoped<IPepsConsultRepository, PepsConsultRepository>();
builder.Services.AddScoped<ICompanyConsultRepository, CompanyConsultRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IConsultServices, ConsultationServices>();
builder.Services.AddScoped<ICompanyServices, CompanyServices>();
builder.Services.AddScoped<IPepsServices, PepsServices>();

builder.Services.AddHttpClient<IBrasilApi, BrasilApi>();
builder.Services.AddHttpClient<IPortalDaTrasparenciaApi, PortalDaTrasparenciaApi>();

builder.Services.AddAutoMapper(typeof(CompanyMapping));
builder.Services.AddAutoMapper(typeof(PepsMapping));

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();