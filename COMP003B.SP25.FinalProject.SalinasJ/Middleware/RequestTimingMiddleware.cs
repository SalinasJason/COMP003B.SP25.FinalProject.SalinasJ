namespace COMP003B.SP25.FinalProject.SalinasJ.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"[Request] {context.Request.Method} {context.Request.Path} {DateTime.Now}");
            await _next(context);
            Console.WriteLine($"[Respones] {context.Response.StatusCode}");

        }
    }
}
