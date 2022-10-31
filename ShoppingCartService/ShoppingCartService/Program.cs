using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCartService.DAL.Implementations;
using ShoppingCartService.DAL.Interfaces;
using ShoppingCartService.Handler.Command.Implementations;
using ShoppingCartService.Handler.Command.Interfaces;
using ShoppingCartService.Handler.Query.Implementations;
using ShoppingCartService.Handler.Query.Interfaces;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.System.Text.Json;
using Microsoft.AspNetCore.Mvc;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApiVersioning();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopping Cart API", Version = "v1" });
        });

        builder.Services.AddStackExchangeRedisExtensions<SystemTextJsonSerializer>((provider) =>
        {
            var config = provider.GetService<IConfiguration>();

            return new List<RedisConfiguration>() { config.GetSection("Redis").Get<RedisConfiguration>() };
        });

        builder.Services.AddScoped<IAddItemToCartCommandHandler, AddItemToCartCommandHandler>();
        builder.Services.AddScoped<IRemoveItemCommandHandler, RemoveItemCommandHandler>();
        builder.Services.AddScoped<IUpdateQuantityCommandHandler, UpdateQuantityQueryHandler>();
        builder.Services.AddScoped<IGetCartQueryHandler, GetCartQueryHandler>();
        builder.Services.AddScoped<IShoppingCartDAL, ShoppingCartDAL>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSwagger();
        app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping Cart V1"));

        app.Run();
    }
}