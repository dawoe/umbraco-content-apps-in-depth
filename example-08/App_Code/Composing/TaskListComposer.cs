namespace TaskListApp
{
    using Umbraco.Core;
    using Umbraco.Core.Composing;
    using Umbraco.Web;

    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    internal class TaskListComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<MigrationComponent>();
            composition.Components().Append<ServerVariablesRegisterComponent>();
            composition.ContentApps().Append<TaskListAppFactory>();
        }
    }
}