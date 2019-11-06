namespace TaskListApp
{
    using Umbraco.Core.Composing;
    using Umbraco.Core.Logging;
    using Umbraco.Core.Migrations;
    using Umbraco.Core.Migrations.Upgrade;
    using Umbraco.Core.Scoping;
    using Umbraco.Core.Services;
    public class MigrationComponent : IComponent
    {
        private readonly IScopeProvider scopeProvider;

        private readonly IMigrationBuilder migrationBuilder;

        private readonly IKeyValueService keyValueService;

        private readonly ILogger logger;

        public MigrationComponent(IScopeProvider scopeProvider, IMigrationBuilder migrationBuilder, IKeyValueService keyValueService, ILogger logger)
        {
            this.scopeProvider = scopeProvider;
            this.migrationBuilder = migrationBuilder;
            this.keyValueService = keyValueService;
            this.logger = logger;
        }

        public void Initialize()
        {
            var upgrader = new Upgrader(new TaskListMigrationPlan());

            upgrader.Execute(this.scopeProvider, this.migrationBuilder, this.keyValueService, this.logger);
        }

        public void Terminate()
        {
        }
    }
}