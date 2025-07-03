using AirlineBookingSystem.Payments.Application.Consumers;
using AirlineBookingSystem.Payments.Application.Handlers;
using AirlineBookingSystem.Payments.Core.Repositories;
using AirlineBookingSystem.Payments.Infrastructure.Repository;
using AirLineBookingSystem.BuildingBlocks.Common;
using AirLineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(ProcessPaymentCommandHandler).Assembly,
    typeof(RefundPaymentCommandHandler).Assembly,
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));



builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);


//Masstransit
builder.Services.AddMassTransit(config =>
{
    // mark as consumer 
    config.AddConsumer<FlightBookedConsumer>();
    config.UsingRabbitMq((ct, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:hostAddress"]);
        cfg.ReceiveEndpoint(EventBusConstant.FlightBookedQueue, c =>
        {
            c.ConfigureConsumer<FlightBookedConsumer>(ct);
        });
    });
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
