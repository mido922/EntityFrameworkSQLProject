// See https://aka.ms/new-console-template for more information
using EntityFrameworkSQLProject;

string userInput;
int a;
toDoTask result;

List<toDoTask> taskList = new List<toDoTask>();


using (var context = new AppDbContext())
{

    while (true)
    {
        Console.WriteLine("----------------\n" +
            "Welcome to the Blackstone To-Do List management app. Please select a choice: \n" +
            "1) View all To-Do tasks. \n" +
            "2) Mark or Unmark a task. \n" +
            "3) Add a task. \n" +
            "4) Remove a task. \n" +
            "5) Close this program.");

        userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                displayTasks();
                break;


            case "2":

                if (!displayTasks())
                {
                    break;
                }

                Console.WriteLine("Which task would you like to change the status of? " +
                                    "Type -1 to exit.");

                userInput = ValidateUserIntegerInput();

                if (userInput == "false")
                {
                    break;
                }

                result = context.toDoTasks.SingleOrDefault(b => b.ID == Convert.ToInt32(userInput));

                if (result.Status == "Unfinished.")
                {
                    result.Status = "Finished.";
                }
                else
                {
                    result.Status = "Unfinished.";
                }
                context.SaveChanges();

                break;
            case "3":
                Console.WriteLine("What would you like to add to your To-Do List?" +
                    "Type -1 to exit.\n");

                while (true)
                {
                    userInput = ValidateUserStringInput();

                    if (userInput == "false")
                    {
                        break;
                    }
                    else
                    {
                        var maxID = 0;
                        if (context.toDoTasks.Count() == 0)
                        {
                            maxID = 1;
                        }
                        else
                            maxID = context.toDoTasks.Max(p => p.ID) + 1;

                        toDoTask asdf = new toDoTask
                        {
                            ID = maxID,
                            Name = userInput,
                            Status = "Unfinished."
                        };

                        context.toDoTasks.Add(asdf);
                        context.SaveChanges();

                        break;
                    }
                }
                break;

            case "4":

                if (!displayTasks()) ;

                Console.WriteLine("What would you like to remove from your To-Do List? Type -1 to exit.\n");

                userInput = ValidateUserIntegerInput();

                if (userInput == "false")
                    break;

                result = context.toDoTasks.SingleOrDefault(b => b.ID == Convert.ToInt32(userInput));
                context.Remove(result);
                context.SaveChanges();
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("That's not a valid input. Please try again.");
                continue;
        }
    }










    Boolean displayTasks()
    {
        taskList = context.toDoTasks.ToList();

        Console.WriteLine("This is" + taskList.Count);

        if (taskList.Count == 0)
        {
            Console.WriteLine("You have no tasks.");
            return false;
        }
        else
        {
            Console.WriteLine("Here is a list of all tasks: \n");
            for (int i = 0; i < taskList.Count; i = i + 1)
            {
                Console.WriteLine($"{taskList[i].ID}) {taskList[i].Name}: {taskList[i].Status}");
                return true;
            }
        }
        return false;
    }

}


string ValidateUserStringInput()
{
    string inputtedUserInput;
    while (true)
    {
        inputtedUserInput = Console.ReadLine();

        if (inputtedUserInput == "-1")
            return ("false");

        else if (inputtedUserInput == "" ||
                int.TryParse(inputtedUserInput, out a))
        {
            Console.WriteLine("That's not a valid input. Please try again.");
            continue;
        }
        else
            return (inputtedUserInput);
    }
}



string ValidateUserIntegerInput()
{
    string inputtedUserInput;
    while (true)
    {
        inputtedUserInput = Console.ReadLine();

        if (inputtedUserInput == "-1")
            return ("false");

        else if (inputtedUserInput == "" ||
                !int.TryParse(inputtedUserInput, out a) ||
                Convert.ToInt32(inputtedUserInput) < 0)
        {
            Console.WriteLine("That's not a valid input. Please try again.");
            continue;
        }
        else
            return (inputtedUserInput);
    }
}
