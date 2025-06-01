using System;

namespace Lab14
{
    public interface IDistribution
    {
        double Generate();
    }

    public class PoissonDistribution : IDistribution
    {
        private readonly double _lambda;

        public PoissonDistribution(double lambda)
        {
            _lambda = lambda;
        }
        
        private readonly Random _rand = new Random();
        
        public double Generate()
        {
            var L = Math.Exp(-_lambda);
            var k = 0;
            double p = 1;
            do
            {
                k++;
                p *= _rand.NextDouble();
            } while (p > L);
            return k - 1;
        }

    }
}