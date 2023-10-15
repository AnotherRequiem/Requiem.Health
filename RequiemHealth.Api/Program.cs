using RequiemHealth.Api.Schema;
using RequiemHealth.DataAccess.Interfaces;
using RequiemHealth.DataAccess.Repositories;
using RequiemHealth.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.MapGraphQL();
app.Seed();
app.Run();