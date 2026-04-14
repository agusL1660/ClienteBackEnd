using System.Diagnostics;

namespace ClienteBackend.Middleware;

public class TiempoMiddleware
{
    private readonly RequestDelegate siguiente;

    public TiempoMiddleware(RequestDelegate next)
    {
        siguiente = next;
    }

    public async Task InvokeAsync(HttpContext contexto)
    {
        var cronometro = Stopwatch.StartNew();

        await siguiente(contexto);
        cronometro.Stop();

        var tiempo = cronometro.Elapsed.TotalMilliseconds;
        Console.WriteLine($" La API tardó {tiempo} ms en responder.");
    }
}