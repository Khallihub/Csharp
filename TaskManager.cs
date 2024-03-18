namespace TaskManager
{
    public enum TaskCategories
    {
        Personal, Work, Errands
    }

    public class Task
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required TaskCategories Category { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class TaskManager
    {
        public static List<Task> Tasks = [];
        static readonly string filepath = "tasks.csv";

        public static void AddTask(string name, string description, TaskCategories category, bool isCompleted)
        {
            Task newTask = new() { Name = name, Description = description, Category = category, IsCompleted = isCompleted };
            Tasks.Add(newTask);
        }
        public static void DisplayTasks()
        {
            foreach (Task task in Tasks)
            {
                Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Category: {task.Category}, IsCompleted: {task.IsCompleted}");
            }
        }
        public static void ViewTasksByCategory(TaskCategories category)
        {
            var filteredTasks = Tasks.Where(task => task.Category == category);
            if (filteredTasks.Count() == 0)
            {
                Console.WriteLine("No tasks found in this category!");
                return;
            }
            foreach (Task task in filteredTasks)
            {
                Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Category: {task.Category}, IsCompleted: {task.IsCompleted}");
            }
        }
        public static async void StoreTasksToCSVAsync()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    foreach (Task task in Tasks)
                    {
                        await writer.WriteLineAsync($"{task.Name},{task.Description},{task.Category},{task.IsCompleted}");
                    }
                }

                Console.WriteLine("Successfully wrote to the file!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }
        public static void LoadTaskFromCSVAsync()
        {
            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    Tasks.Clear();
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] taskValues = line.Split(',');

                        string taskName = taskValues[0];
                        string taskDescription = taskValues[1];
                        TaskCategories taskCategories;
                        if (Enum.TryParse(taskValues[2], true, out taskCategories))
                        {
                        }
                        else
                        {
                            Console.WriteLine("Invalid CSV format!");
                            return;
                        }
                        bool isCompleted = Convert.ToBoolean(taskValues[3]);

                        Task newTask = new Task() { Name = taskName, Description = taskDescription, Category = taskCategories, IsCompleted = isCompleted };
                        Tasks.Add(newTask);
                    }
                    Console.WriteLine("Successfully loaded tasks");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from a file: " + ex.Message);
            }
        }
        public static void UpdateTask(string name, string description, TaskCategories category, bool isCompleted)
        {
            Task? curTask = Tasks.Find(task => task.Name == name);
            if (curTask != null)
            {
                curTask.Name = name;
                curTask.Description = description;
                curTask.Category = category;
                curTask.IsCompleted = isCompleted;
            }
            else
            {
                Console.WriteLine($"Task with name {name} not found");
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new() { Name = "laundary", Description = "do the laundary", Category = TaskCategories.Personal, IsCompleted = true };
            TaskManager taskManager = new();
            TaskManager.LoadTaskFromCSVAsync();
            Console.WriteLine("Your Task Manager is ready");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter 1 to add a task");
                Console.WriteLine("Enter 2 to display tasks");
                Console.WriteLine("Enter 3 to view tasks by category");
                Console.WriteLine("Enter 4 to store tasks to CSV");
                Console.WriteLine("Enter 5 to load tasks from CSV");
                Console.WriteLine("Enter 6 to update a task");
                Console.WriteLine("Enter 0 to exit");
                Console.WriteLine();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter task name");
                        string? name = Console.ReadLine();
                        if (name == "" || name == null)
                        {
                            Console.WriteLine("Task name cannot be empty");
                            break;
                        }
                        Console.WriteLine("Enter task description");
                        string? description = Console.ReadLine();
                        if (description == "" || description == null)
                        {
                            description = "No description provided";
                        }
                        Console.WriteLine("Enter task category. Personal, Work, Errands");
                        TaskCategories category;
                        if (Enum.TryParse(Console.ReadLine(), true, out category))
                        {
                        }
                        else
                        {
                            Console.WriteLine("Invalid category");
                            break;
                        }
                        Console.WriteLine("Enter 1 if the task is completed, 0 if not");
                        int tmp = Convert.ToInt32(Console.ReadLine());
                        bool isCompleted = tmp == 1;
                        TaskManager.AddTask(name, description, category, isCompleted);
                        Console.WriteLine("Task added successfully");
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        TaskManager.DisplayTasks();
                        break;
                    case 3:
                        Console.WriteLine("Enter task category");
                        Console.WriteLine("Enter 1 for Personal, 2 for Work, 3 for Errands");
                        string? tmps = Console.ReadLine();
                        if (tmps == "" || tmps == null)
                        {
                            Console.WriteLine("Invalid category");
                            break;
                        }
                        int tmpi = Convert.ToInt32(tmps);
                        category = (TaskCategories)Enum.Parse(typeof(TaskCategories), (tmpi - 1).ToString());
                        TaskManager.ViewTasksByCategory(category);
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        TaskManager.StoreTasksToCSVAsync();
                        Thread.Sleep(2000);

                        break;
                    case 5:
                        TaskManager.LoadTaskFromCSVAsync();
                        Thread.Sleep(2000);
                        break;
                    case 6:
                        Console.WriteLine("Enter task name");
                        name = Console.ReadLine();
                        if (name == "" || name == null)
                        {
                            Console.WriteLine("Task name cannot be empty");
                            break;
                        }
                        Console.WriteLine("Enter new task name");
                        name = Console.ReadLine();
                        if (name == "" || name == null)
                        {
                            Console.WriteLine("Task name cannot be empty");
                            break;
                        }
                        Console.WriteLine("Enter task description");
                        description = Console.ReadLine();
                        if (description == "" || description == null)
                        {
                            description = "No description provided";
                        }
                        Console.WriteLine("Enter task category");
                        tmps = Console.ReadLine();
                        if (tmps == "" || tmps == null)
                        {
                            Console.WriteLine("Invalid category");
                            break;
                        }
                        tmpi = Convert.ToInt32(tmps);
                        category = (TaskCategories)Enum.Parse(typeof(TaskCategories), (tmpi - 1).ToString()); Console.WriteLine("Enter task status");
                        isCompleted = Convert.ToBoolean(Console.ReadLine());
                        TaskManager.UpdateTask(name, description, category, isCompleted);
                        Thread.Sleep(2000);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                if (choice == 0)
                {
                    break;
                }

            }
        }
    }
}
