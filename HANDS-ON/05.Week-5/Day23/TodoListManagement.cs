namespace TodoListManagement
{
    class Tasks
    {
        private List<string> tasks = new List<string>();
        public void AddTasks(string task)
        {
            tasks.Add(task);
            Console.WriteLine("Task added!\n");
        }

        public void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Task list is empty");
                return;
            }
            Console.WriteLine("\nTasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }

        }

        public void RemoveTask(int taskNumber)
        {
            if (taskNumber < 1 || taskNumber > tasks.Count)
            {
                Console.WriteLine("Invalid task number.");
                return;
            }
            string removedTask = tasks[taskNumber - 1];
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine($"Removed: {removedTask}\n");
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Tasks tasks = new Tasks();


            while (true)
            {
                Console.WriteLine("\nTo-Do List Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");

                string input = Console.ReadLine();
                int choice;

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input. Enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter task: ");
                        string task = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(task))
                        {
                            Console.WriteLine("Task cannot be empty.");
                        }
                        else
                        {
                            tasks.AddTasks(task);
                        }
                        break;

                    case 2:
                        tasks.ViewTasks();
                        break;

                    case 3:
                        Console.WriteLine("Enter task number to remove: ");
                        string removeInput = Console.ReadLine();
                        int taskNum;

                        if (int.TryParse(removeInput, out taskNum))
                        {
                            tasks.RemoveTask(taskNum);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter a number.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid option! Please select from (1-4)");
                        break;

                }
            }

        }
    }
}
