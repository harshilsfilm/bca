using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQ
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public string City { get; set; }
    }
    public partial class WebForm1 : System.Web.UI.Page
    {

        class Program
        {
            static void Main(string[] args)
            {
                // List Collection
                List<Student> students = new List<Student>()
            {
                new Student { Id = 1, Name = "Amit", Marks = 85, City = "Ahmedabad" },
                new Student { Id = 2, Name = "Neha", Marks = 72, City = "Surat" },
                new Student { Id = 3, Name = "Rahul", Marks = 90, City = "Ahmedabad" },
                new Student { Id = 4, Name = "Pooja", Marks = 60, City = "Rajkot" },
                new Student { Id = 5, Name = "Karan", Marks = 75, City = "Surat" }
            };

                Console.WriteLine("===== LINQ QUERY SYNTAX =====");

                // WHERE
                var q1 = from s in students
                         where s.Marks > 70
                         select s;

                Print(q1);

                Console.WriteLine("\n===== LINQ METHOD SYNTAX =====");

                // WHERE
                var q2 = students.Where(s => s.Marks > 70);
                Print(q2);

                // SELECT
                var names = students.Select(s => s.Name);
                Console.WriteLine("\nNames:");
                foreach (var n in names)
                    Console.WriteLine(n);

                // ORDER BY
                Console.WriteLine("\nOrder By Marks:");
                Print(students.OrderBy(s => s.Marks));

                // ORDER BY DESCENDING
                Console.WriteLine("\nOrder By Descending:");
                Print(students.OrderByDescending(s => s.Marks));

                // AGGREGATE FUNCTIONS
                Console.WriteLine("\n===== AGGREGATE FUNCTIONS =====");
                Console.WriteLine("Max Marks: " + students.Max(s => s.Marks));
                Console.WriteLine("Min Marks: " + students.Min(s => s.Marks));
                Console.WriteLine("Average Marks: " + students.Average(s => s.Marks));
                Console.WriteLine("Total Marks: " + students.Sum(s => s.Marks));
                Console.WriteLine("Count: " + students.Count());

                // FIRST
                Console.WriteLine("\nFirst Student: " + students.First().Name);

                // FIRST OR DEFAULT
                var f1 = students.FirstOrDefault(s => s.Marks > 95);
                Console.WriteLine("FirstOrDefault: " + (f1 == null ? "No Record" : f1.Name));

                // LAST
                Console.WriteLine("Last Student: " + students.Last().Name);

                // LAST OR DEFAULT
                var l1 = students.LastOrDefault(s => s.Marks < 50);
                Console.WriteLine("LastOrDefault: " + (l1 == null ? "No Record" : l1.Name));

                // SINGLE
                Console.WriteLine("\nSingle Example:");
                var singleStudent = students.Single(s => s.Id == 3);
                Console.WriteLine(singleStudent.Name);

                // SINGLE OR DEFAULT
                var sdef = students.SingleOrDefault(s => s.Id == 10);
                Console.WriteLine(sdef == null ? "SingleOrDefault: No Record" : sdef.Name);

                // GROUP BY
                Console.WriteLine("\n===== GROUP BY CITY =====");
                var group = students.GroupBy(s => s.City);

                foreach (var g in group)
                {
                    Console.WriteLine("City: " + g.Key);
                    foreach (var st in g)
                    {
                        Console.WriteLine("  " + st.Name);
                    }
                }

                Console.WriteLine("\n===== AGGREGATE USING Aggregate() =====");
                int total = students.Select(s => s.Marks)
                                    .Aggregate((a, b) => a + b);
                Console.WriteLine("Total Marks using Aggregate(): " + total);

                Console.ReadLine();
            }

            // Helper Method
            static void Print(IEnumerable<Student> list)
            {
                foreach (var s in list)
                {
                    Console.WriteLine($"{s.Id} {s.Name} {s.Marks} {s.City}");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}