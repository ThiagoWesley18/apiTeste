using Microsoft.AspNetCore.Mvc.Filters;

namespace apiTeste.Filter
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ILogger<LoggingFilter> _logger;

        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger;
        }

        // Executa antes da Action
        public void OnActionExecuting(ActionExecutingContext context)
        {

            _logger.LogInformation("###############################");
            _logger.LogInformation("Executando OnActionExecuting...");
            _logger.LogInformation($"{DateTime.Now.ToShortTimeString()}");
            _logger.LogInformation("###############################");
        }

        // Executa depois da Action
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("###############################");
            _logger.LogInformation("Executando OnActionExecuted...");
            _logger.LogInformation($"{DateTime.Now.ToString()}");
            _logger.LogInformation($"Status Code - {context.HttpContext.Response.StatusCode}");
            _logger.LogInformation("###############################");

        }

    }
}
