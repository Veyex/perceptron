using System;
using System.Collections.Generic;

namespace perceptron
{
    internal class Program
    {
        static void Main()
        {
            //most basic version of the perceptron

            //setup
            Random RNG = new Random();
            double[] inputs0 = new double[] { 1, 1, 1, 1 };
            double[] inputs1 = new double[] { 0, 1, 0, 1 };
            double[] inputs2 = new double[] { 0, 0, 1, 1 };
            List<Double[]> inputs = new List<Double[]> { inputs0, inputs1, inputs2};

            double[] tarOutputs = new double[] { 0, 0, 0, 1 };

            double[] weights = new double[] { RNG.NextDouble(), RNG.NextDouble(), RNG.NextDouble() };

            //learning stage
            double learnRate = 1;
            double[] calcOutputs = new double[4];
            for (int n = 0; n < 10000; n++)
            {
                for (int i = 0; i < inputs1.Length; i++)
                {
                    calcOutputs[i] = Sigmoid((inputs0[i] * weights[0]) + (inputs1[i] * weights[1]) + (inputs2[i] * weights[2]));
                    for (int j = 0; j < weights.Length; j++)
                    {
                        weights[j] += learnRate * (tarOutputs[i] - calcOutputs[i]) * inputs[j][i];
                    }
                }
            }

            //print final outputs
            foreach (double a in calcOutputs)
            {
                Console.WriteLine(a);
            }
        }

        //sigmoid function
        static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}
