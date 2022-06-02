using MediatR;
using Welldium.Application.NotificationHandlers;
using Welldium.Application.Notifications;
using Welldium.Domain;
using Welldium.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISimulationRepository, SimulationRepository>();
builder.Services.AddScoped<INotificationHandler<CreateSimulationNotification>, CreateSimulationNotificationHandler>();
builder.Services.AddScoped<INotificationHandler<CreateRobotNotification>, CreateRobotNotificationHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
