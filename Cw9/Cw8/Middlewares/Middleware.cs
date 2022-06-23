using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cw8.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly string path = "logs.txt";

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public  async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }catch (Exception ex)
            {
                using var stream = new StreamWriter(path, true);
                await stream.WriteLineAsync($"{DateTime.Now}, {ex}");
                await _next(httpContext);
            }
        }
    }



    // Extension method used to add the middleware to the HTTP request pipeline.
   
}
