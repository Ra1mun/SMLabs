// Абстрактный класс для всех агентов

using System;
using System.Collections.Generic;

public abstract class Agent
    {
        public string Name { get; set; }

        protected Agent(string name)
        {
            Name = name;
        }
    }

    // Клиент - агент
    public class Customer : Agent
    {
        public double ArrivalTime { get; set; }

        public Customer(string name, double arrivalTime) : base(name)
        {
            ArrivalTime = arrivalTime;
        }
    }

    // Банкир - обслуживающий агент
    public class BankTeller : Agent
    {
        private bool isBusy;
        private double serviceTimeMean;
        private Random rand;

        public event Action<Customer, double> CustomerServiced;

        public BankTeller(string name, double serviceTimeMean) : base(name)
        {
            this.serviceTimeMean = serviceTimeMean;
            rand = new Random();
        }

        public void Serve(Customer customer, double currentTime)
        {
            if (!isBusy)
            {
                isBusy = true;

                var serviceDuration = GenerateServiceTime();
                Console.WriteLine($"[t={currentTime:F2}] Начало обслуживания клиента {customer.Name}.");

                var finishTime = currentTime + serviceDuration;
                Console.WriteLine($"[t={finishTime:F2}] Завершено обслуживание клиента {customer.Name}.");
                CustomerServiced?.Invoke(customer, finishTime);

                isBusy = false;
            }
        }

        private double GenerateServiceTime()
        {
            var r = rand.NextDouble();
            return -Math.Log(1.0 - r) * serviceTimeMean; // Экспоненциальное распределение
        }

        public bool IsBusy => isBusy;
    }

    // Менеджер очереди
    public class QueueManager
    {
        private Queue<Customer> queue = new Queue<Customer>();

        public void Enqueue(Customer customer)
        {
            queue.Enqueue(customer);
        }

        public Customer Dequeue()
        {
            return queue.Count > 0 ? queue.Dequeue() : null;
        }

        public int Count => queue.Count;
    }