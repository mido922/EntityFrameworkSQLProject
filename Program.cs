// See https://aka.ms/new-console-template for more information
using EntityFrameworkSQLProject;

Console.WriteLine("Hello, World!");


using (var context = new AppDbContext())
{
    var newToDoTask = new toDoTask { ID = 2, Name = "Test", Status = "Unfinished." };
        context.toDoTasks.Add(newToDoTask);
    context.SaveChanges();
    Console.WriteLine("Finished");

    var toDoTasks = context.toDoTasks.ToList();
    Console.WriteLine(toDoTasks[0].Name, toDoTasks[0].Status);
}