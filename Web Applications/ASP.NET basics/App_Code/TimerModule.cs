using System;
using System.Diagnostics;
using System.Web;

namespace EpamWeb
{
    public class TimerModule : IHttpModule
    {
        private Stopwatch _elapsedTime;

        private void OnBeginRequest(object sender, EventArgs e)
        {

            HttpContext httpContext = HttpContext.Current; ;
            string path = httpContext.Request.FilePath;
            string extension = VirtualPathUtility.GetExtension(path);

            if (extension == ".epam")
            {
                _elapsedTime = Stopwatch.StartNew();
            }
        }

        private void OnEndRequest(object sender, EventArgs e)
        {
            HttpContext httpContext = HttpContext.Current;
            string path = httpContext.Request.FilePath;
            string extension = VirtualPathUtility.GetExtension(path);

            if (extension == ".epam")
            {
                httpContext.Response.Write(
                    $"<div><b> Request handling time: " +
                    $"{(double)_elapsedTime.ElapsedTicks / Stopwatch.Frequency:F5} seconds</b></div>");
            }
            
        }

        public void Dispose() { }

        public void Init(HttpApplication context)
        {
                context.BeginRequest += this.OnBeginRequest;
                context.EndRequest += this.OnEndRequest;       
        }
    }
}