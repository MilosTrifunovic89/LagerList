namespace Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.LagerListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            MigrationsAssembly = Assembly.GetExecutingAssembly();
            MigrationsNamespace = "Model.Migrations";
            
        }

        protected override void Seed(Model.LagerListContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
