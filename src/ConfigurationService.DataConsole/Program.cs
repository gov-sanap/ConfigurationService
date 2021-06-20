using ConfigurationService.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationService.DataConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var dataProvider = new DataProvider();

                var res = dataProvider.GetEntityConfiguration("",null);


                using (var ctx = new EntityConfigurationContext())
                {
                    //ctx.Database.ExecuteSqlCommand("Select * from ");
                    var entityConfigurationData = new EntityConfigurationData() { Id = Guid.NewGuid(), EntityName = "something", FieldName = "firlsd", FieldSource = "source1", IsRequired = true, MaxLength = 120 };

                    ctx.EntityConfigurations.Add(entityConfigurationData);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            try
            {
                using (var context = new MyContext())
                {
                    // Create and save a new Students
                    Console.WriteLine("Adding new students");

                    var student = new Student
                    {
                        FirstMidName = "Alain",
                        LastName = "Bomer",
                        EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                    };

                    context.Students.Add(student);

                    var student1 = new Student
                    {
                        FirstMidName = "Mark",
                        LastName = "Upston",
                        EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                    };

                    context.Students.Add(student1);
                    context.SaveChanges();

                    // Display all Students from the database
                    var students = (from s in context.Students
                                    orderby s.FirstMidName
                                    select s).ToList<Student>();

                    Console.WriteLine("Retrieve all Students from the database:");

                    foreach (var stdnt in students)
                    {
                        string name = stdnt.FirstMidName + " " + stdnt.LastName;
                        Console.WriteLine("ID: {0}, Name: {1}", stdnt.ID, name);
                    }

                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }

    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
        [ForeignKey("ID")]
        public virtual Student Student { get; set; }
    }

    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        //public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

    public class MyContext : DbContext
    {
        public MyContext() : base("name = MyContextDB")
        {
            Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
        }
        //public virtual DbSet<Course> Courses { get; set; }
        //public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
