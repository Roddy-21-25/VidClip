using VidClip.Api.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddScoped<IBusinessLogic, BusinessLogic>();

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "VideoGenerator", builder =>
    {
        builder.WithOrigins("*");
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Cors
app.UseCors("VideoGenerator");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
