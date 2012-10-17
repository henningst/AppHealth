using System.Web;

namespace AppHealth
{
    class HealthCheckHttpHandler: IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<html><head><title>AppHealth</title></head><body>");
            context.Response.Write("<h1>AppHealth</h1>");
            context.Response.Write("<table><tr><td>Name</td><td>Status</td></tr>");

            var hc = new HealthChecker();
            var status = hc.GetStatus();
            foreach (var s in status)
            {
                context.Response.Write(string.Format("<tr><td>{0}</td><td>{1}</td>", s.Name, s.IsUp ? "I'm Up" : "I'm Down"));
            }

            context.Response.Write("</table>");
            context.Response.Write("</body>");
            context.Response.Write("</html>");
        }

        public bool IsReusable { get; private set; }
    }
}
