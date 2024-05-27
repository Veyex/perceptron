using System;
using System.Collections.Generic;

namespace perceptron
{
    internal class Program
    {
        static void Main()
        {
            //modular version of the base branch

            double[] inputs1 = new double[] { 0, 1, 0, 1 };
            double[] inputs2 = new double[] { 0, 0, 1, 1 };
            double[] tarOutputs = new double[] { 0, 0, 0, 1 };

            Perceptron p = new Perceptron();
            p.Train(inputs1, inputs2, tarOutputs, 10000);
            for (int i = 0; i<inputs1.Length; i++)
            {
                Console.WriteLine(p.CalculateOutput(inputs1[i], inputs2[i])); 
            }
        }
    }
}
