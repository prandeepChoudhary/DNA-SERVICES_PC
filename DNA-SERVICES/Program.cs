
using DNA_SERVICES.Application.Helper;
using DNA_SERVICES.Application.Interface;
using DNA_SERVICES.Application.Services;
using DNA_SERVICES.Domain.Interfaces.Domain;
using DNA_SERVICES.Domain.Interfaces.Repository;
using DNA_SERVICES.Domain.Services;
using DNA_SERVICES.Infrastructure.Repository;

namespace DNA_SERVICES;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

        builder.Services.AddTransient<IFeeScheduleService, FeeScheduleServices>();
        builder.Services.AddTransient<IFeeScheduleDomainService, FeeScheduleDomainServices>();
        builder.Services.AddTransient<IFeeScheduleRepository, FeeScheduleRepository>();

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
    }
}

