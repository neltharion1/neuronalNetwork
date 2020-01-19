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
        private ErrorForm errorForm;
        public nnMath() { }
        public double[,] matrixMult(double[,] matr1, double[,] matr2)
        {
            int rowMatr1 = matr1.GetLength(0);
            int colMatr1 = matr1.GetLength(1);
            int rowMatr2 = matr2.GetLength(0);
            int colMatr2 = matr2.GetLength(1);
            double temp = 0;
            double[,] resMatr = new double[rowMatr1, colMatr2];
            if (colMatr1 != rowMatr2)
            {
                Console.WriteLine("Matrix kann nicht multipliziert werden!");
            }
            else
            {
                for (int i = 0; i < rowMatr1; i++)
                {
                    for (int j = 0; j < colMatr2; j++)
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

        public double[] matrixMult(double[,] matr1, double[] matr2)
        {
            int rowMatr1 = matr1.GetLength(0);
            int colMatr1 = matr1.GetLength(1);
            int rowMatr2 = matr2.GetLength(0);
            double temp = 0;
            double[] resMatr = new double[rowMatr1];
            if (colMatr1 != rowMatr2)
            {
                Console.WriteLine("Matrix kann nicht multipliziert werden!");
                errorForm = new ErrorForm();
                errorForm.setError("Matrix kann nicht multipliziert werden!");
                errorForm.Visible = true;

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

        public double[,] matrixMult(double[] vec1, double[] vec2)
        {
            int colVec1 = vec1.GetLength(0);
            int rowVec2 = vec2.GetLength(0);
            double[,] resMatr = new double[colVec1, rowVec2];

            for (int i = 0; i < colVec1; i++)
            {
                for (int j = 0; j < rowVec2; j++)
                {
                    resMatr[i, j] = vec1[i] * vec2[j];
                }
            }
            return resMatr;
        }

        public double[,] matrixSum(double[,] mat1, double[,] mat2)
        {
            int rowMatr1 = mat1.GetLength(0);
            int colMatr1 = mat1.GetLength(1);
            int rowMatr2 = mat2.GetLength(0);
            int colMatr2 = mat2.GetLength(1);
            double[,] resMatr = new double[rowMatr1, colMatr2];
            if(rowMatr1 == rowMatr2 && colMatr1 == colMatr2)
            {
                for(int i=0; i < rowMatr1; i++)
                {
                    for(int j=0; j < colMatr1; j++)
                    {
                        resMatr[i, j] = mat1[i, j] + mat2[i, j];
                    }
                }
            }
            else
            {
                errorForm = new ErrorForm();
                errorForm.setError("Matrix kann nicht Addiert werden!");
                errorForm.Visible = true;
            }

            return resMatr;
        }

        public double[] vectorMult(double[] vec1, double[] vec2)
        {
            int colVec1 = vec1.GetLength(0);
            int colVec2 = vec2.GetLength(0);
            double[] resVec = new double[colVec1];

            if(colVec1 == colVec2)
            {
                for(int i = 0; i < colVec1; i++)
                {
                    resVec[i] = vec1[i] * vec2[i];
                }
            }
            else
            {
                errorForm = new ErrorForm();
                errorForm.setError("Vektoren können nicht multipliziert werden!");
                errorForm.Visible = true;
            }

            return resVec;
        }

        public double[] vectoradd_sub(double[] vec1, double[] vec2, bool addition)
        {
            int colVec1 = vec1.GetLength(0);
            int colVec2 = vec2.GetLength(0);
            double[] resVec = new double[colVec1];
            if (colVec1 == colVec2)
            {
                for(int i=0; i < colVec1; i++)
                {
                    if (addition == true)
                    {
                        resVec[i] = vec1[i] + vec2[i];
                    }
                    else
                    {
                        resVec[i] = vec1[i] - vec2[i];
                    }
                }
            }
            else
            {
                errorForm = new ErrorForm();
                errorForm.setError("Vektoren können nicht addiert werden!");
                errorForm.Visible = true;
            }
            return resVec;
        }

        public double[] vectoradd_sub(double vec1, double[] vec2, bool addition)
        {
            
            int colVec2 = vec2.GetLength(0);
            double[] resVec = new double[colVec2];
            
                for (int i = 0; i < colVec2; i++)
                {
                    if (addition == true)
                    {
                        resVec[i] = vec1 + vec2[i];
                    }
                    else
                    {
                        resVec[i] = vec1 - vec2[i];
                    }
                }
           
            return resVec;
        }

        public double[,] transpose(double[,] matr)
        {
            int rowMatr = matr.GetLength(0);
            int colMatr = matr.GetLength(1);
            double[,] resMatr = new double[colMatr, rowMatr];

            for(int i=0; i<rowMatr;i++)
            {
                for(int j=0; j < colMatr; j++)
                {
                    resMatr[i, j] = matr[j, i];
                }
            }

            return resMatr;
        }

        public double[,] matrixScale(double[,] matr, double scale)
        {
            int rowMatr = matr.GetLength(0);
            int colMatr = matr.GetLength(1);
            double[,] resMatr = new double[rowMatr, colMatr];
            for(int i = 0; i < rowMatr; i++)
            {
                for(int j=0; j < colMatr; j++)
                {
                    resMatr[i, j] = scale * matr[i, j];
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
