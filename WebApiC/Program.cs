using WebApiC.Models;
using WebApiC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});

builder.Services.AddSingleton<TodoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.Run();