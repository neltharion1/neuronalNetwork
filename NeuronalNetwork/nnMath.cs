using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NeuronalNetwork
{
    class nnMath
    {
        private double[] resSigmoid;
        public nnMath() { }
        public double[,] matixMult(double[,] matr1, double[,] matr2)
        {
            int rowMatr1 = matr1.GetLength(0);
            int colMatr1 = matr1.GetLength(1);
            int rowMatr2 = matr2.GetLength(0);
            int colMatr2 = matr2.GetLength(1);
            double temp = 0;
            double[,] resMatr = new double[rowMatr1, colMatr2];
            if(colMatr1 != rowMatr2)
            {
                Console.WriteLine("Matrix kann nicht multipliziert werden!");
            }
            else
            {
                for(int i = 0; i < rowMatr1; i++)
                {
                    for(int j = 0; j < colMatr2; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < colMatr1; k++)
                        {
                            temp += matr1[i, k] * matr2[k, j];
                        }
                        resMatr[i, j] = temp;
                    }
                }
            }
            return resMatr;
        }

        public double[] matixMultVec(double[,] matr1, double[] matr2)
        {
            int rowMatr1 = matr1.GetLength(0);
            int colMatr1 = matr1.GetLength(1);
            int rowMatr2 = matr2.GetLength(0);            
            double temp = 0;
            double[] resMatr = new double[rowMatr1];
            if (colMatr1 != rowMatr2)
            {
                Console.WriteLine("Matrix kann nicht multipliziert werden!");
            }
            else
            {
                for (int i = 0; i < rowMatr1; i++)
                {                  
                    temp = 0;
                    for (int k = 0; k < colMatr1; k++)
                    {
                        temp += matr1[i, k] * matr2[k];
                    }
                    resMatr[i] = temp;
                    
                }
            }
            return resMatr;
        }
        public double[] sigmoid(double[] x)
        {
            resSigmoid = new double[x.GetLength(0)];
            for (int i = 0; i < x.GetLength(0); i++)
            {
                resSigmoid[i] = (1 / (1 + Math.Exp(-x[i])));
            }
            return resSigmoid;
        }
    }
}
