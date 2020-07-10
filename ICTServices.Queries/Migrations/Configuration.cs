namespace API.Queries.Migrations
{
    using API.Queries.Core.Domain;
    using API.Queries.Core.Domain.Auth;
    using API.Queries.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<API.Queries.Persistence.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(API.Queries.Persistence.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            #region Add Permissions
            var permissions = new Dictionary<string, Permission>
            {
                ////Users Lookup
                //{"1", new Permission {PermissionID = 1, Description = "User - Add"}},
                //{"2", new Permission {PermissionID = 2, Description = "User - Delete"}},
                //{"3", new Permission {PermissionID = 3, Description = "User - Save"}},
                //{"4", new Permission {PermissionID = 4, Description = "Permission - Delete"}},
                //{"5", new Permission {PermissionID = 5, Description = "Permission - Check All"}},
                //{"6", new Permission {PermissionID = 6, Description = "Permission - Add"}},
                //{"7", new Permission {PermissionID = 7, Description = "Permission - Insert All"}},
                //{"8", new Permission {PermissionID = 8, Description = "User Lookup"}},
                ////Login
                //{"9", new Permission {PermissionID = 9, Description = "Login"}},
                ////Employee Lookup
                //{"10", new Permission {PermissionID = 10, Description = "Employee Lookup"}},
                //{"11", new Permission {PermissionID = 11, Description = "Employee - Add"}},
                //{"12", new Permission {PermissionID = 12, Description = "Employee - Delete"}},
                //{"13", new Permission {PermissionID = 13, Description = "Employee - Save"}},
                // //Item Lookup
                //{"14", new Permission {PermissionID = 14, Description = "Item Lookup"}},
                //{"15", new Permission {PermissionID = 15, Description = "Item - Add"}},
                //{"16", new Permission {PermissionID = 16, Description = "Item - Delete"}},
                //{"17", new Permission {PermissionID = 17, Description = "Item - Save"}},
                // //Reservation
                //{"18", new Permission {PermissionID = 18, Description = "Reservation"}},
                //{"19", new Permission {PermissionID = 19, Description = "Reservation - Add"}},
                //{"20", new Permission {PermissionID = 20, Description = "Reservation - Delete"}},
                ////Reservation Lookup
                //{"21", new Permission {PermissionID = 21, Description = "Reservation - Save"}},
                //{"22", new Permission {PermissionID = 22, Description = "Reservation - Reset"}},
                // //Device Setup
                //{"23", new Permission {PermissionID = 23, Description = "Device Setup"}},

            };

            foreach (var permission in permissions.Values)
                context.AuthPermissions.AddOrUpdate(t => t.PermissionID, permission);
            #endregion

            #region Add Users
            var users = new Dictionary<string, User>
            {
                {"admin", 
                    new User 
                    { UserID = 1, 
                        FirstName = "admin", 
                        MiddleName ="admin", 
                        LastName="admin",
                        UserName ="admin",
                        Password = "2ZVtITjEtc4TCUIBlwxuXr97aapPgo6ET+SW9RZCTHHtbvtw92AmTSE21dMRqswJNuiSMkArA8kFNc88KFmxOQ==",
                        PasswordSalt="100000.EU4kEMpmyVlxVH3tDFLvjj4pvgxGPqBmAM/dM79E1dT1yg==",
                        Role= SysRole.Admin
                    }
                }

            };

            foreach (var user in users.Values)
                context.AuthUsers.AddOrUpdate(t => t.UserID, user);
            #endregion
        }
    }
}
