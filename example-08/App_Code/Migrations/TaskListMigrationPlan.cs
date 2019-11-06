namespace TaskListApp
{
    public class TaskListMigrationPlan : Umbraco.Core.Migrations.MigrationPlan
    {
        public TaskListMigrationPlan()
            : base("TaskList")
        {
            this.InitialInstall();
        }
        public override string InitialState => string.Empty;
        private void InitialInstall()
        {
            this.From(this.InitialState)
                .To<CreateTableMigration>("1.0.0-tasklisttable");
        }
    }
}