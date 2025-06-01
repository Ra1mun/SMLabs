using System;

namespace Lab14
{
    public class Simulation
    {
        private QueueManager queueManager = new QueueManager();
        private BankTeller teller;
        private double interArrivalTimeMean;
        private Random rand = new Random();
        private int customerIdCounter = 1;

        public Simulation(double interArrivalTimeMean, double serviceTimeMean)
        {
            this.interArrivalTimeMean = interArrivalTimeMean;
            teller = new BankTeller("Банкир", serviceTimeMean);
            teller.CustomerServiced += OnCustomerProcessed;
        }

        public void Run(double simulationTime)
        {
            double currentTime = 0.0;

            Console.WriteLine("Запуск симуляции...");

            while (currentTime < simulationTime)
            {
                double interArrival = GenerateInterArrivalTime();
                currentTime += interArrival;

                var customer = new Customer($"Клиент{customerIdCounter++}", currentTime);
                Console.WriteLine($"[t={currentTime:F2}] Прибыл {customer.Name}.");
                queueManager.Enqueue(customer);

                ProcessQueue(currentTime);
                System.Threading.Thread.Sleep(100); // Визуализация
            }

            // Обслужить оставшихся в очереди
            while (queueManager.Count > 0)
            {
                ProcessQueue(currentTime);
                currentTime += 0.1;
                System.Threading.Thread.Sleep(50);
            }

            Console.WriteLine("Моделирование завершено.");
        }

        private double GenerateInterArrivalTime()
        {
            double r = rand.NextDouble();
            return -Math.Log(1.0 - r) * interArrivalTimeMean; // Экспоненциальное
        }

        private void ProcessQueue(double currentTime)
        {
            if (!teller.IsBusy)
            {
                var customer = queueManager.Dequeue();
                if (customer != null)
                {
                    teller.Serve(customer, currentTime);
                }
            }
        }

        private void OnCustomerProcessed(Customer customer, double finishTime)
        {
            Console.WriteLine($"[t={finishTime:F2}] {customer.Name} ушёл из банка.");
        }
    }
}