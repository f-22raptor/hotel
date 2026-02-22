using Application;
using Domain.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
// swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
// AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(ApplicationAssemblyMarker).Assembly);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.MapOpenApi();
    // scalar
    // app.MapScalarApiReference();    
    // swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
