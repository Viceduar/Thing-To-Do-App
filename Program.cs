using System;
using System.Collections.Generic;

namespace ThingsToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            while (true)
            {
                DisplayMainMenu();
                int option = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Write a task to do: ");
                        string descriptionTask = Console.ReadLine();
                        tasks.Add(new Task(descriptionTask));
                        ConfirmMessage("Task added successfully");
                        break;
                    case 2:
                        if (tasks.Count == 0)
                        {
                            ConfirmMessage("Empty List");
                        }
                        else
                        {
                            ShowTasks(tasks);
                            Console.Write("Number of task you want to delete: ");
                            int deleteTaskIndex = int.Parse(Console.ReadLine());
                            if (deleteTaskIndex > tasks.Count)
                            {
                                ConfirmMessage("Invalid option");
                            }
                            else
                            {
                                tasks.RemoveAt(deleteTaskIndex - 1);
                                ConfirmMessage($"Task {deleteTaskIndex} was deleted");
                            }
                        }
                        break;
                    case 3:
                        ShowTasks(tasks);
                        Console.Write("Number of tasks you want to edit: ");
                        int editTaskIndex = int.Parse(Console.ReadLine());

                        if (editTaskIndex > tasks.Count)
                        {
                            ConfirmMessage("Invalid option");
                        }
                        else
                        {
                            Console.WriteLine("1. Change description");
                            Console.WriteLine("2. Change status");
                            int selection = int.Parse(Console.ReadLine());

                            if (selection == 1)
                            {
                                Console.WriteLine("Enter new description: ");
                                string newDescription = Console.ReadLine();
                                tasks[editTaskIndex - 1].Description = newDescription;
                            }
                            else if (selection == 2)
                            {
                                tasks[editTaskIndex - 1].ChangeStatus();
                            }
                            else
                            {
                                ConfirmMessage("Invalida option");
                                break;
                            }

                            ConfirmMessage("Task edited successfully");
                        }
                        break;
                    case 4:
                        ShowTasks(tasks);
                        ConfirmMessage();
                        break;
                    case 5:
                        Console.WriteLine("So long!");
                        return;
                    default:
                        ConfirmMessage("Invalid option");
                        break;
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("THINGS TO DO APP");
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. Delete task");
            Console.WriteLine("3. Edit task");
            Console.WriteLine("4. Show tasks");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter an option: ");
        }

        static void ShowTasks(List<Task> tasks)
        {
            Console.WriteLine("TASKS:");
            Console.WriteLine("Description \t\t Status \t\t Date Creation");
            for (int i = 0; i < tasks.Count; i++)
            {
                string currentStatus = (tasks[i].Status ? "Complete" : "Uncomplete");
                Console.WriteLine($"{i + 1} {tasks[i].Description} \t\t {currentStatus} \t\t {tasks[i].Date}");
            }
        }
        static void ConfirmMessage(string message = "")
        {
            Console.WriteLine(message);
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Task
    {
        private string description;
        private bool status;
        private DateTime date = DateTime.Now;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Task(string description)
        {
            Description = description;
            Status = false;
            Date = DateTime.Now;
        }

        public void ChangeStatus()
        {
            Status = !Status;
        }
    }
}