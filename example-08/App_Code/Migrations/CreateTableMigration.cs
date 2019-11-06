namespace TaskListApp
{
    using System;
    using Umbraco.Core.Migrations;
    public class CreateTableMigration : MigrationBase
    {
        public CreateTableMigration(IMigrationContext context)
            : base(context)
        {
        }
        public override void Migrate()
        {
            this.Create.Table<Task>().Do();
        }
    }
}