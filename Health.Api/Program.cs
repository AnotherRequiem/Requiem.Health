using Health.Api.Schema.Mutations;
using Health.Api.Schema.Queries;
using Health.Persistence;
using Health.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();
                
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddDbContextFactory<ApplicationDbContext>();
builder.Services.AddScoped<HospitalRepository>()
                .AddScoped<DepartmentRepository>();

var app = builder.Build();

app.UseRouting();
app.MapGraphQL();
app.Seed();
app.Run();