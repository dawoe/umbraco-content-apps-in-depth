namespace TaskListApp
{
    using System.Collections.Generic;
    using System.Linq;

    using Umbraco.Core.Models;
    using Umbraco.Core.Models.ContentEditing;
    using Umbraco.Core.Models.Membership;
    using Umbraco.Core.Scoping;
    using Umbraco.Web.Security;

    public class TaskListAppFactory : IContentAppFactory
    {
        private readonly IScopeProvider scopeProvider;

        public TaskListAppFactory(IScopeProvider scopeProvider)
        {
            this.scopeProvider = scopeProvider;
        }

        public ContentApp GetContentAppFor(object source, IEnumerable<IReadOnlyUserGroup> userGroups)
        {
            if (!(source is IContent))
            {
                return null;
            }

            var tasks = new List<Task>();

            using (var scope = this.scopeProvider.CreateScope(autoComplete: true))
            {
                tasks = scope.Database.Fetch<Task>().ToList();
            }

            return new ContentApp
                       {
                           Alias = "tasklistapp",
                           Icon = "icon-notepad",
                           Name = "Tasks",
                           View = "/App_Plugins/TaskList/view.html",
                           ViewModel = tasks
                       };
        }
    }

}