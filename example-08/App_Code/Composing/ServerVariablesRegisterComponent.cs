namespace TaskListApp
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Umbraco.Core.Composing;
    using Umbraco.Web;
    using Umbraco.Web.JavaScript;

    public class ServerVariablesRegisterComponent : IComponent
    {
        public void Initialize()
        {
            ServerVariablesParser.Parsing += this.ServerVariablesParserParsing;
        }

        public void Terminate()
        {
            
        }

        private void ServerVariablesParserParsing(object sender, Dictionary<string, object> e)
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            var urlHelper = new UrlHelper(new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData()));

            var urlDictionairy = new Dictionary<string, object>
                                     {
                                         {
                                             "TaskListApi",
                                             urlHelper.GetUmbracoApiServiceBaseUrl<TaskListApiController>(c => c.CreateTask(null))
                                         }
                                     };


            if (!e.Keys.Contains("TaskList"))
            {
                e.Add("TaskList", urlDictionairy);
            }
        }
    }
}
