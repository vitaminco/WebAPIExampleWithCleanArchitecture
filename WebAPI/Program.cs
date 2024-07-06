//using tạo db
using Application.Configurations;
using Infrastructure.DependencyInjection;
using Infrastructure.Handlers.ExampleHandler.Queries;
using Infrastructure.Handlers.SampleHandler.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//sử dụng dịch vụ để tạo db
builder.Services.InFrastrutureServics(builder.Configuration);
//Sử dụng automapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
//Sử dụng MediatR 
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllExampleHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateSampleHandler).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
