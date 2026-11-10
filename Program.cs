using Microsoft.EntityFrameworkCore;

using (var context = new SchoolContext())
{
    // Creates the database and the Students table if they don't exist yet (Code-First)
    context.Database.EnsureCreated();

    // Add one student
    var student = new Student { StudentName = "John Smith" };
    context.Students.Add(student);
    context.SaveChanges();

    // Show all students in the database
    Console.WriteLine("Students in the database:");
    foreach (var s in context.Students.ToList())
    {
        Console.WriteLine($"{s.StudentId}: {s.StudentName}");
    }
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();

// The model class - Entity Framework creates the Students table from this
public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = "";
}

// The database context - connects the model to the database
public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=StudentDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}