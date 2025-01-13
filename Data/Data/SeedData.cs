using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageInstall.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageInstall.Data.Data
{
    public static class SeedData
    {
        public static List<MainTable> MainTables => new List<MainTable>
        {
            new MainTable { ID = 1, EnglishText = "First Name" },
                new MainTable { ID = 2, EnglishText = "Last Name" },
                new MainTable { ID = 3, EnglishText = "Submit" },
                new MainTable { ID = 4, EnglishText = "Home" },
                new MainTable { ID = 5, EnglishText = "Human Resource Management" },
                new MainTable { ID = 6, EnglishText = "Leave Management" },
                new MainTable { ID = 7, EnglishText = "Operation" },
                new MainTable { ID = 8, EnglishText = "Leave Application Entry" },
                new MainTable { ID = 9, EnglishText = "Company" },
                new MainTable { ID = 10, EnglishText = "Employee ID" },
                new MainTable { ID = 11, EnglishText = "Employee Name" },
                new MainTable { ID = 12, EnglishText = "Designation" },
                new MainTable { ID = 13, EnglishText = "Department" },
                new MainTable { ID = 14, EnglishText = "Immediate Supervisor" },
                new MainTable { ID = 15, EnglishText = "Head of Department" },
                new MainTable { ID = 16, EnglishText = "Apply Leave Format" },
                new MainTable { ID = 17, EnglishText = "Leave Type" },
                new MainTable { ID = 18, EnglishText = "From" },
                new MainTable { ID = 19, EnglishText = "Day(s)" },
                new MainTable { ID = 20, EnglishText = "To" },
                new MainTable { ID = 21, EnglishText = "Half Day" },
                new MainTable { ID = 22, EnglishText = "First Half" },
                new MainTable { ID = 23, EnglishText = "Second Half" },
                new MainTable { ID = 24, EnglishText = "File Attachment" },
                new MainTable { ID = 25, EnglishText = "Reason" },
                new MainTable { ID = 26, EnglishText = "Leave Apply" },
                new MainTable { ID = 27, EnglishText = "Select Dropdown Options" },
                new MainTable { ID = 28, EnglishText = "--Select--" },
                new MainTable { ID = 29, EnglishText = "--Select Apply Leave Format--" },
                new MainTable { ID = 30, EnglishText = "Half Day Leave" },
                new MainTable { ID = 31, EnglishText = "Full Day Leave" },
                new MainTable { ID = 32, EnglishText = "Short Leave" },
                new MainTable { ID = 33, EnglishText = "--Select--" },
                new MainTable { ID = 34, EnglishText = "Button and Action Text" },
                new MainTable { ID = 35, EnglishText = "Leave Apply" },
                new MainTable { ID = 36, EnglishText = "Half Day" },
                new MainTable { ID = 37, EnglishText = "Full Day" },
                new MainTable { ID = 38, EnglishText = "Short Leave" }

        };
        //public static void Initialize(IServiceProvider serviceProvider)
        //{
        //    using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        //    {
        //        if (context.MainTables.Any())
        //        {
        //            return;   // DB has been seeded
        //        }

        //        var mainTables = new List<MainTable>
        //        {
        //            new MainTable { EnglishText = "First Name" },
        //            new MainTable { EnglishText = "Last Name" },
        //            new MainTable { EnglishText = "Submit" },
        //            new MainTable { EnglishText = "Home" },
        //            new MainTable { EnglishText = "Human Resource Management" },
        //            new MainTable { EnglishText = "Leave Management" },
        //            new MainTable { EnglishText = "Operation" },
        //            new MainTable { EnglishText = "Leave Application Entry" },
        //            new MainTable { EnglishText = "Company" },
        //            new MainTable { EnglishText = "Employee ID" },
        //            new MainTable { EnglishText = "Employee Name" },
        //            new MainTable { EnglishText = "Designation" },
        //            new MainTable { EnglishText = "Department" },
        //            new MainTable { EnglishText = "Immediate Supervisor" },
        //            new MainTable { EnglishText = "Head of Department" },
        //            new MainTable { EnglishText = "Apply Leave Format" },
        //            new MainTable { EnglishText = "Leave Type" },
        //            new MainTable { EnglishText = "From" },
        //            new MainTable { EnglishText = "Day(s)" },
        //            new MainTable { EnglishText = "To" },
        //            new MainTable { EnglishText = "Half Day" },
        //            new MainTable { EnglishText = "First Half" },
        //            new MainTable { EnglishText = "Second Half" },
        //            new MainTable { EnglishText = "File Attachment" },
        //            new MainTable { EnglishText = "Reason" },
        //            new MainTable { EnglishText = "Leave Apply" },
        //            new MainTable { EnglishText = "Select Dropdown Options" },
        //            new MainTable { EnglishText = "--Select--" },
        //            new MainTable { EnglishText = "--Select Apply Leave Format--" },
        //            new MainTable { EnglishText = "Half Day Leave" },
        //            new MainTable { EnglishText = "Full Day Leave" },
        //            new MainTable { EnglishText = "Short Leave" },
        //            new MainTable { EnglishText = "--Select--" },
        //            new MainTable { EnglishText = "Button and Action Text" },
        //            new MainTable { EnglishText = "Leave Apply" },
        //            new MainTable { EnglishText = "Half Day" },
        //            new MainTable { EnglishText = "Full Day" },
        //            new MainTable { EnglishText = "Short Leave" },
        //            new MainTable { EnglishText = "Other" },
        //            new MainTable { EnglishText = "--Select Employee--" },
        //            new MainTable { EnglishText = "Cancel" },
        //            new MainTable { EnglishText = "Entry ID" },
        //            new MainTable { EnglishText = "Select Leave Format" },
        //            new MainTable { EnglishText = "Select Leave Type" },
        //            new MainTable { EnglishText = "Sick Leave" },
        //            new MainTable { EnglishText = "Casual Leave" },
        //            new MainTable { EnglishText = "Leave Duration" },
        //            new MainTable { EnglishText = "Additional Information" },
        //            new MainTable { EnglishText = "Select Employee" },
        //        };

        //        context.MainTables.AddRange(mainTables);
        //        context.SaveChanges();
        //    }
        //}
    }
}
