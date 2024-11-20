using asp_hw02.Command;
using asp_hw02.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace asp_hw02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(policy =>
            //    {
            //        policy.AllowAnyOrigin()
            //              .AllowAnyMethod()
            //              .AllowAnyHeader();
            //    });
            //});
            var app = builder.Build();

            //app.UseCors(); 
            //// Включаем CORS


            //app.UseExceptionHandler(errorApp =>
            //{
            //    errorApp.Run(async context =>
            //    {
            //        context.Response.ContentType = "application/problem+json";
            //        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            //        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            //        if (exceptionHandlerPathFeature?.Error is not null)
            //        {
            //            var problemDetails = new ProblemDetails
            //            {
            //                Status = StatusCodes.Status500InternalServerError,
            //                Title = "An unexpected error occurred!",
            //                Detail = exceptionHandlerPathFeature.Error.Message,
            //                Instance = context.Request.Path
            //            };

            //            await context.Response.WriteAsJsonAsync(problemDetails);
            //        }
            //    });
            //});

            app.MapGet("/", () => TasksDB.Managers);
            app.MapGet("/getbyname", (string name) => ManagerCommands.GetTask(name));
            app.MapPost("/send", ([FromBody] Manager manager) => ManagerCommands.AddTask(manager.Name, manager.Description, manager.isCompleted)).WithParameterValidation();
            app.MapDelete("/delete", (string name) => ManagerCommands.DeleteTask(name));
            app.MapPut("/update", (string name, string? newName, string? newDescription, bool? isCompleted) =>
                ManagerCommands.Update(name, newName, newDescription, isCompleted)).WithParameterValidation();



            app.Run();
        }
    }
}
