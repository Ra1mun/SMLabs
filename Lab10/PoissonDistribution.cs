using System;

namespace Lab10
{
    public class PoissonDistribution
    {
        private readonly Random _rand = new Random();
        
        public int Generate(double lambda)
        {
            var L = Math.Exp(-lambda);
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