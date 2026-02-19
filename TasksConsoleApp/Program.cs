using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessLayerOfTasks;

namespace TasksConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITaskServices taskServices=new clsTaskServices();
            Console.WriteLine("Task Services Initialized");
            foreach (var task in taskServices.GetAllTasks())
            {
                Console.WriteLine($"Task: {task.Title}, Progress: {task.IsCompleted}");
            }
            Console.WriteLine("Adding a new task...");
            string newTaskTitle;
            int TrueOrFalse = 0;
            do
            {
                Console.Write("Enter the title of the new task: ");
                newTaskTitle = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newTaskTitle))
                {
                    Console.WriteLine("Task title cannot be empty. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(newTaskTitle));
            do
            {
                Console.WriteLine("Enter 1 for True or 0 for False: ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    TrueOrFalse = 1;
                }
                else if (input == "0")
                {
                    TrueOrFalse = 0;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 for True or 0 for False.");
                }
            } while (TrueOrFalse != 1 && TrueOrFalse != 0);
            bool isCompleted = TrueOrFalse == 1;
            taskServices.AddTask(new clsTask { Title = newTaskTitle, IsCompleted = isCompleted });
            
            Console.WriteLine("Task added successfully.");

        }
    }
}
