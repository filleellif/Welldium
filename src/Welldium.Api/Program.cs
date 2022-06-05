using MediatR;
using System.Text.Json.Serialization;
using Welldium.Application.NotificationHandlers;
using Welldium.Application.Notifications;
using Welldium.Domain;
using Welldium.Infrastructure;
using Welldium.ReadModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISimulationRepository, SimulationRepository>();
builder.Services.AddScoped<INotificationHandler<CreateSimulationNotification>, CreateSimulationNotificationHandler>();
builder.Services.AddScoped<INotificationHandler<CreateRobotNotification>, CreateRobotNotificationHandler>();
builder.Services.AddScoped<INotificationHandler<RemoveRobotNotification>, RemoveRobotNotificationHandler>();
builder.Services.AddScoped<INotificationHandler<MoveRobotNotification>, MoveRobotNotificationHandler>();
builder.Services.AddScoped<ISimulationQueries, SimulationQueries>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
