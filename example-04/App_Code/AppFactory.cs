using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Core.Models.ContentEditing;
using Umbraco.Core.Models.Membership;

namespace ContentAppsInDepth
{
    public class ExampleFourApp : IContentAppFactory
    {
        public ContentApp GetContentAppFor(object source, IEnumerable<IReadOnlyUserGroup> userGroups)
        {
            if (!(source is IContent))
            {
                return null;
            }

            if (userGroups.Any(x => x.Alias.ToLowerInvariant() == "admin") == false)
            {
                return null;
            }

            var content = source as IContent;

            if (content.Id == 0)
            {
                return null;
            }

            var exampleApp = new ContentApp
            {
                Alias = "example04",
                Name = "Example 04",
                Icon = "icon-piracy",
                View = "/App_Plugins/Example04/view.html",
                Weight = 0,
                ViewModel = "This is data set from the factory"
            };
            return exampleApp;
        }
    }
}