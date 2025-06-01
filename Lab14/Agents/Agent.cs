// Абстрактный класс для всех агентов

using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Lab14.Agents
{
    public abstract class Agent
    {
        public string Name { get; set; }

        protected Agent(string name)
        {
            Name = name;
        }
    }

    public class Customer : Agent
    {
        public double ArrivalTime { get; set; }
        public double ServiceStartTime { get; set; }
        public double ServiceEndTime { get; set; }
        public double QueueTime => ServiceStartTime - ArrivalTime;
        public double TotalTime => ServiceEndTime - ArrivalTime;

        public Customer(string name, double arrivalTime) : base(name)
        {
            ArrivalTime = arrivalTime;
        }
    }

    public class Source : Agent
    {
        private readonly PoissonDistribution _distribution;
        private double _nextGenerationTime;
        public event Action<Customer> CustomerGenerated;

        public Source(string name, double lambda) : base(name)
        {
            _distribution = new PoissonDistribution(lambda);
            _nextGenerationTime = 0;
        }

        public bool ShouldGenerateCustomer(double currentTime)
        {
            if (currentTime >= _nextGenerationTime)
            {
                _nextGenerationTime = currentTime + _distribution.Generate();
                return true;
            }
            return false;
        }

        public void GenerateCustomer(double currentTime)
        {
            var customer = new Customer($"Customer_{Guid.NewGuid().ToString().Substring(0, 8)}", currentTime);
            Console.WriteLine($"[t={currentTime:F2}] {customer.Name} arrived");
            CustomerGenerated?.Invoke(customer);
        }
    }

    public class Queue : Agent
    {
        private readonly Queue<Customer> _customers;
        public event Action<Customer> CustomerDequeued;

        public Queue(string name) : base(name)
        {
            _customers = new Queue<Customer>();
        }

        public void Enqueue(Customer customer)
        {
            _customers.Enqueue(customer);
        }

        public Customer Dequeue()
        {
            if (_customers.Count > 0)
            {
                var customer = _customers.Dequeue();
                CustomerDequeued?.Invoke(customer);
                return customer;
            }
            return null;
        }

        public int Count => _customers.Count;
    }

    public class Service : Agent
    {
        private readonly PoissonDistribution _distribution;
        private bool _isBusy;
        public event Action<Customer> CustomerServiced;

        public Service(string name, double lambda) : base(name)
        {
            _distribution = new PoissonDistribution(lambda);
        }

        public void ProcessCustomer(Customer customer, double currentTime)
        {
            if (_isBusy) return;

            _isBusy = true;
            customer.ServiceStartTime = currentTime;

            var serviceDuration = _distribution.Generate();
            customer.ServiceEndTime = currentTime + serviceDuration;

            Thread.Sleep(serviceDuration);
            CustomerServiced?.Invoke(customer);
            _isBusy = false;
        }

        public bool IsBusy => _isBusy;
    }

    public class Output : Agent
    {
        private readonly List<Customer> _processedCustomers;
        public event Action<Customer> CustomerProcessed;

        public Output(string name) : base(name)
        {
            _processedCustomers = new List<Customer>();
        }

        public void ProcessCustomer(Customer customer)
        {
            _processedCustomers.Add(customer);
            CustomerProcessed?.Invoke(customer);
        }

        public double AverageQueueTime => _processedCustomers.Count > 0 
            ? _processedCustomers.Average(c => c.QueueTime) 
            : 0;

        public double AverageTotalTime => _processedCustomers.Count > 0 
            ? _processedCustomers.Average(c => c.TotalTime) 
            : 0;

        public int TotalProcessedCustomers => _processedCustomers.Count;
    }
}