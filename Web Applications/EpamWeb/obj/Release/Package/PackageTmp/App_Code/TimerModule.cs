using System;
using System.Diagnostics;
using System.Web;

public class TimerModule : IHttpModule
{
    private Stopwatch elapsedTime;

    private void OnBeginRequest(object sender, EventArgs e) => elapsedTime = Stopwatch.StartNew();

    private void OnEndRequest(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        context.Response.Write($"<div> Request handling time: {(double)elapsedTime.ElapsedTicks / Stopwatch.Frequency} seconds</div>");
    }

    public void Dispose() { }

    public void Init(HttpApplication context)
    {
        context.BeginRequest += this.OnBeginRequest;
        context.EndRequest += this.OnEndRequest;
    }
}