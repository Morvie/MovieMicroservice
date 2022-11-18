using MovieMicroservice.Interface.Service;
using MovieMicroservice.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile("/app/secrets/appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
    
//Dependency injection
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ICreditsService, CreditsService>();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
