using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace ContentAppsInDepth
{
    public class ExampleFourAppComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.ContentApps().Append<ExampleFourApp>();
        }
    }
}