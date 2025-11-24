//Add a new class and implement the built-in UseExceptionHandler method
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

public static class ExceptionHandlerMiddlewareExtension
{
      public static void AddExceptionHandler(this IApplicationBuilder app)
      {
          app.UseExceptionHandler(error =>
          {
              error.Run(async context =>
              {

                  context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                  context.Response.ContentType = "application/json";

                  var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                  if (contextFeature != null)
                  {
                      string message = "Internal server error";
                      await context.Response.WriteAsync(JsonConvert.SerializeObject(new { 
                        StatusCode = context.Response.StatusCode, 
                        Message = message, Status = VarHelper.ResponseStatus.ERROR.ToString() }));
                  }
              });
          });
      }
  }

public static class VarHelper
{
    public enum ResponseStatus
    {
        ERROR,
        SUCCESS
    }
}