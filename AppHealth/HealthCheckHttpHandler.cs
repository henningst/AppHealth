using System.Web;
using System.Web.Script.Serialization;

namespace AppHealth
{
    public class HealthCheckHttpHandler: IHttpHandler
    {
        private HealthChecker _hc;

        public HealthCheckHttpHandler()
        {
            _hc = new HealthChecker();
        }

        public void ProcessRequest(HttpContext context)
        {
            if(context.Request.RawUrl.Contains("/api/status"))
            {
                WriteJsonStatusPage(context);
            }
            else
            {
                WriteHtmlStatusPage(context);    
            }
        }

        public bool IsReusable { get; private set; }

        public void WriteHtmlStatusPage(HttpContext context)
        {
            context.Response.Write("<html><head><title>AppHealth</title></head><body>");
            context.Response.Write("<h1>AppHealth</h1>");
            context.Response.Write("<table border='1'><tr><td><b>Name</b></td><td><b>Status</b></td><td><b>Response time</b></tr>");

            var status = _hc.GetStatus();
            foreach (var s in status)
            {
                context.Response.Write(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2} ms</td></tr>", s.Name, s.IsUp ? "I'm Up" : "I'm Down", s.ResponseTime));
            }

            context.Response.Write("</table>");
            context.Response.Write("</body>");
            context.Response.Write("</html>");            
        }

        public void WriteJsonStatusPage(HttpContext context)
        {
            var serializer = new JavaScriptSerializer();
            context.Response.ContentType = "application/json";
            context.Response.Write(serializer.Serialize(_hc));
        }
    }
}
