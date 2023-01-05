using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Pin.CricketDarts.Server.Services.Api;
using Pin.CricketDarts.Server.Services.Interfaces;

namespace Pin.CricketDarts.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSignalR();
            builder.Services.AddTransient<IPlayerService, PlayerService>();
            builder.Services.AddTransient<IGameService, GameService>();
            builder.Services.AddTransient<IScoreBoardEntryService, ScoreBoardEntryService>();
            builder.Services.AddTransient<ITurnService, TurnService>();
            builder.Services.AddScoped<HttpClient>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}