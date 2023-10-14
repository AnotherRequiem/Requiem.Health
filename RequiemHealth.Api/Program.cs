using RequiemHealth.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

app.Seed();
app.Run();