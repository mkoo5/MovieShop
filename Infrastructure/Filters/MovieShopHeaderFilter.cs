using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Filters
{
    // this gets called repeatedly 
    public class MovieShopHeaderFilter : IActionFilter
    {
        private readonly ICurrentUserService _currentUserService;

        public MovieShopHeaderFilter(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        // before action method
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Log each and every user's IP address, his name if authenticated, authentication status, date time
            // context.HttpContext.Response.Headers.Add("job", "antra.com/jobs");

            var email = _currentUserService.Email;
            var datetime = DateTime.UtcNow;
            var isAuthenticated = _currentUserService.IsAuthenticated;
            var name = _currentUserService.FullName;

            // log this info to text files
            // System.IO
            // Serilog, NLog, Log4net
            Log.Logger = new LoggerConfiguration().WriteTo.File("log.txt").CreateLogger();
            Log.Information(email);
            Log.Information(datetime.ToString());
            Log.Information(isAuthenticated.ToString());
            Log.Information(name);
            Log.CloseAndFlush();
        }

        // after action method
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
