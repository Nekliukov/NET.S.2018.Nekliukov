using System.Web;

public class EpamFormatHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        HttpRequest Request = context.Request;
        HttpResponse Response = context.Response;
        // This handler is called whenever a file ending 
        // in .sample is requested. A file with that extension
        // does not need to exist.
        Response.Write("<html>");
        Response.Write("<body>");
        Response.Write("<h1>Hello from a synchronous custom HTTP handler. AYY LMAO </h1>");
        Response.Write("</body>");
        Response.Write("</html>");
    }

    public bool IsReusable => false;
}