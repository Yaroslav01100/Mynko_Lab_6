using System;
using System.Collections.Generic;

namespace Lab_6_task_4
{
public class TaskScheduler<TTask, TPriority> where TPriority : IComparable<TPriority>
{
    private class TaskItem
    {
        public TTask Task { get; set; }
        public TPriority Priority { get; set; }
    }

    private readonly Queue<TaskItem> taskQueue = new Queue<TaskItem>();

    public delegate void TaskExecution(TTask task);

    public void AddTask(TTask task, TPriority priority)
    {
        taskQueue.Enqueue(new TaskItem { Task = task, Priority = priority });
    }

    public void ExecuteNext(TaskExecution executeTask)
    {
        if (taskQueue.Count > 0)
        {
            TaskItem nextTask = taskQueue.Dequeue();
            executeTask(nextTask.Task);
        }
        else
        {
            Console.WriteLine("Немає завдань у черзі.");
        }
    }

    public TTask GetFromPool(Func<TTask> initializeTask)
    {
        return initializeTask();
    }

    public void ReturnToPool(TTask task, Action<TTask> resetTask)
    {
        resetTask(task);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Минко Ярослав");

        TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>();

        Console.WriteLine("Введіть завдання з пріоритетами (натисніть Enter, щоб завершити):");
        while (true)
        {
            Console.Write("завдання: ");
            string task = Console.ReadLine();

            if (string.IsNullOrEmpty(task))
                break;

            Console.Write("Пріоритет: ");
            if (int.TryParse(Console.ReadLine(), out int priority))
            {
                scheduler.AddTask(task, priority);
            }
            else
            {
                Console.WriteLine("Недійсний пріоритет. Введіть дійсне ціле число.");
            }
        }

        scheduler.ExecuteNext(Console.WriteLine);

        string pooledTask = scheduler.GetFromPool(() => "Об'єднане завдання");
        Console.WriteLine("Об'єднане завдання: " + pooledTask);
        scheduler.ReturnToPool(pooledTask, t => Console.WriteLine("Скидання об’єднаного завдання: " + t));
    }
}


}