using System;
using System.Collections.Generic;

namespace Lab6v16
{
    public interface IQueueProcessor<T>
    {
        void ProcessItem(T item);
    }

    public class EmailProcessor : IQueueProcessor<string>
    {
        public void ProcessItem(string item)
        {
            Console.WriteLine("Email: " + item);
        }
    }

    public class SmsProcessor : IQueueProcessor<string>
    {
        public void ProcessItem(string item)
        {
            Console.WriteLine("SMS: " + item);
        }
    }

    public abstract class WorkflowStep
    {
        public abstract bool ExecuteStep();

        public void LogStepCompletion(string stepName)
        {
            Console.WriteLine("Крок " + stepName + " виконано.");
        }
    }

    public class DataValidationStep : WorkflowStep
    {
        public override bool ExecuteStep()
        {
            Console.WriteLine("Перевірка даних...");
            LogStepCompletion("DataValidationStep");
            return true;
        }
    }

    public class DataTransformationStep : WorkflowStep
    {
        public override bool ExecuteStep()
        {
            Console.WriteLine("Трансформація даних...");
            LogStepCompletion("DataTransformationStep");
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<IQueueProcessor<string>> processors = new List<IQueueProcessor<string>>();
            processors.Add(new EmailProcessor());
            processors.Add(new SmsProcessor());

            foreach (var p in processors)
            {
                p.ProcessItem("Тестове повідомлення");
            }

            Console.WriteLine();

            List<WorkflowStep> steps = new List<WorkflowStep>();
            steps.Add(new DataValidationStep());
            steps.Add(new DataTransformationStep());

            foreach (var step in steps)
            {
                step.ExecuteStep();
            }
        }
    }
}