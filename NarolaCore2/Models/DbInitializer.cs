using Microsoft.AspNetCore.Identity;
using NarolaCore2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NarolaCore2.Models
{
    public interface IDbInitializer
    {
        void Initialize();
    }
    public class DbInitializer : IDbInitializer
    {
        private readonly SchoolContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DbInitializer(
            SchoolContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async void Initialize()
        {
            _context.Database.EnsureCreated();

            // Look for any students.
            if (_context.Students.Any())
            {
                return;   // DB has been seeded
            }

            ////If there is already an Administrator role, abort
            //if (_context.Roles.Any(r => r.Name == "Administrator")) return;

            ////Create the Administartor Role
            //await _roleManager.CreateAsync(new ApplicationRole { Name = "Administrator" });

            //Create the default Admin account and apply the Administrator role
            //string user = "abp@narola.email";
            //string password = "Password@123";
            //await _userManager.CreateAsync(new ApplicationUser { UserName = user, Email = user, EmailConfirmed = true }, password);
           // await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user), "Administrator");


            var students = new Student[]
            {
            new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                _context.Students.Add(s);
            }
            _context.SaveChanges();

            var courses = new Course[]
            {
            new Course{Title="Chemistry",Credits=3,},
            new Course{Title="Microeconomics",Credits=3,},
            new Course{Title="Macroeconomics",Credits=3,},
            new Course{Title="Calculus",Credits=4,},
            new Course{Title="Trigonometry",Credits=4,},
            new Course{Title="Composition",Credits=3,},
            new Course{Title="Literature",Credits=4,}
            };
            foreach (Course c in courses)
            {
                _context.Courses.Add(c);
            }
            _context.SaveChanges();

            
        }
    }
}
