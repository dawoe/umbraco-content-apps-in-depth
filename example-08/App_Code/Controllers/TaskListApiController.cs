namespace TaskListApp
{
    using System;
    using System.Net.Http;
    using System.Web.Http;

    using Umbraco.Core.Scoping;
    using Umbraco.Web.Mvc;
    using Umbraco.Web.WebApi;

    [PluginController("TaskList")]
    public class TaskListApiController : UmbracoAuthorizedApiController
    {
        protected readonly IScopeProvider scopeProvider;

        public TaskListApiController(IScopeProvider scopeProvider)
        {
            this.scopeProvider = scopeProvider;
        }

        [HttpPost]
        public HttpResponseMessage CreateTask(Task task)
        {
            try
            {
                task.CreateDate = DateTime.Now;
                task.CreatedBy = this.Security.CurrentUser.Id;

                using (var scope = this.scopeProvider.CreateScope(autoComplete: true))
                {
                    using (var transaction = scope.Database.GetTransaction())
                    {
                        scope.Database.Insert(task);

                        transaction.Complete();
                    }                  
                }

                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, task);
            }
            catch (Exception exception)
            {
                return this.Request.CreateNotificationValidationErrorResponse(exception.Message);
            }
        }

        
    }
}