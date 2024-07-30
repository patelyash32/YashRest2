
using AutoMapper;
using CustomerAPI.Interfaces;
using CustomerAPI.Models;
using CustomerAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerAPI
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);            
            builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(Mapping).Assembly);            
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();            
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
}


