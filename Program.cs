using MovieMicroservice.Interface.Service;
using MovieMicroservice.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
