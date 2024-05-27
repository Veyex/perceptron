using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perceptron
{
    class Perceptron
    {
        Random RNG = new Random();
        double[] inputs0 = new double[] { 1, 1, 1, 1 };
        List<Double[]> inputs;
        double[] weights;
        double learnRate = 1;

        public Perceptron()
        {
            weights = new double[] { RNG.NextDouble(), RNG.NextDouble(), RNG.NextDouble() };
        }

        public void ResetWeights()
        {
            weights = new double[] { RNG.NextDouble(), RNG.NextDouble(), RNG.NextDouble() };
        }

        public void Train(double[] inputs1, double[] inputs2, double[] tarOutputs, int cycles, double lr = 1)
        {
            learnRate = lr;
            inputs = new List<Double[]> { inputs0, inputs1, inputs2 };

            double[] calcOutputs = new double[4];
            for (int n = 0; n < cycles; n++)
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
        }

        public double CalculateOutput(double x1, double x2)
        {
            return Sigmoid(weights[0] + (x1 * weights[1]) + (x2 * weights[2]));
        }

        static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}
