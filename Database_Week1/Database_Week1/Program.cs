using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Database_Week1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                /* Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();
                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges(); */

                // Create and save a new Organization
                Console.Write("\nNow enter ID of your Organization: ");
                var OrgID = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nNow enter the name of your Organization: ");
                var OrgName = Console.ReadLine();
                var Organization1 = new Organization { OrganizationID = OrgID, OrganizationName = OrgName };
                db.Organization.Add(Organization1);
                db.SaveChanges();

                //Assign a user to the organization
                Console.Write("\n Now enter a Username linked to the organization \n");
                var UsrNam = Console.ReadLine();
                var User1 = new User {Username = UsrNam, Organization = Organization1 };
                db.Users.Add(User1);
                db.SaveChanges();


                /*// Display all Blogs from the database
                var BlogWrite = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("\nAll blogs in the database:\n");
                foreach (var item in BlogWrite)
                {
                    Console.WriteLine(item.Name);
                }
            */
               

                //Display users assigned to organizations
                var UserOrgWrite = from a in db.Users
                               orderby a.Username
                               select a;
                foreach (var item in UserOrgWrite)
                {

                    Console.WriteLine(item.Username + " is Assigned to the organization: " + item.Organization.OrganizationName);
                }


                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        public class Blog
        {
            public int BlogId { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
            public virtual List<Post> Posts { get; set; }
        }

        public class Post
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            public int BlogId { get; set; }
            public virtual Blog Blog { get; set; }
        }

        public class User
        {
            [Key]
            public string Username { get; set; }
            public string DisplayName { get; set; }
            public virtual Organization Organization { get; set; }
        }
       
        public class Organization
        {
            public int OrganizationID { get; set; }
            public string OrganizationName { get; set; }
            public virtual List<Country> Homelands { get; set; }
        }

        public class Country
        {
            public int CountryID { get; set; }
            public string CountryName { get; set; }
            public int  CountryCode{ get; set; }
            public virtual List<Organization> OrgsInCountry { get; set; }

        }

        public class BloggingContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Organization> Organization { get; set; }
            public DbSet<Country> Countries { get; set; }


            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>()
                    .Property(u => u.DisplayName)
                    .HasColumnName("display_name");
            }
        }
    }
}
