namespace TodoApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TodoApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoApp.Models.TodoesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TodoApp.Models.TodoesContext";
        }

        protected override void Seed(TodoApp.Models.TodoesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            User admin = new User()
            {
                Id = 1,
                UserName = "admin",
                Password = "password",
                Roles = new List<Role>()
            };

            User nishida = new User()
            {
                Id = 2,
                UserName = "niishida",
                Password="password",
                Roles = new List<Role>()
            };

            Role administrators = new Role()
            {
                Id = 1,
                RoleName = "Administrators",
                Users = new List<User>()
            };

            Role users = new Role()
            {
                Id = 2,
                RoleName = "Users",
                Users = new List<User>()
            };

            admin.Roles.Add(administrators);
            administrators.Users.Add(admin);
            nishida.Roles.Add(users);
            users.Users.Add(nishida);

            context.Users.AddOrUpdate(user => user.Id, new User[] { admin, nishida });
            context.Roles.AddOrUpdate(role => role.Id, new Role[] { administrators, users });

        
        }
    }
}
