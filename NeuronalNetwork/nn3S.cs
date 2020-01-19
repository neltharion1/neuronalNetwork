using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalNetwork
{
    class nn3S
    {
        private double[] final_inputs;
        private double[] final_outputs;
        private double[] hidden_inputs;
        private double[] hidden_outputs;
        private double[] hidden_errors;
        private int hnodes, innodes, onodes, hiddenLayers;
        private double[,] who, wih;
        private double learningRate;
        private double[] output_errors;
        private double[,] weightMatr_temp;
        private nnMath nnmath = new nnMath();
        private List<double[,]> weightList = new List<double[,]>();
        private List<double[,]> weightList_temp = new List<double[,]>();

        private List<double[]> inputList = new List<double[]>();
        private List<double[]> outputList = new List<double[]>();
        private List<double[]> errorList = new List<double[]>();


        public double[] Final_inputs { get { return final_inputs; } set { final_inputs = value; } }
        public double[] Final_outputs { get { return final_outputs; } set { final_outputs = value; } }
        public double[] Hidden_inputs { get { return hidden_inputs; } set { hidden_inputs = value; } }
        public double[] Hidden_outputs { get { return hidden_outputs; } set { hidden_outputs = value; } }
        public double[] Hidden_errors { get { return hidden_errors; } set { hidden_errors = value; } }
        public double[] Output_errors { get { return output_errors; } set { output_errors = value; } }
        public double[,] WHO { get { return who; } }
        public double[,] WIH { get { return wih; } }
        public List<double[,]> WeightList { get { return weightList; } }
        public nn3S(int innodes, int hnodes, int onodes, double learningRate, int hiddenLayers)
        {
            this.innodes = innodes;
            this.hnodes = hnodes;
            this.onodes = onodes;
            this.learningRate = learningRate;
            this.hiddenLayers = hiddenLayers;
            createWeightMatrizes();
        }

        private void createWeightMatrizes()
        {
            
           /* wih = new double[,]{ { 0.9, 0.3, 0.4 }, { 0.2, 0.8, 0.2 }, { 0.1,0.5,0.6} };
            who = new double[,] { { 0.3, 0.7, 0.5 }, { 0.6, 0.5, 0.2 }, { 0.8, 0.1, 0.9 } };
            for(int i =0; i< wih.GetLength(0); i++)
            {
                for(int j = 0; j < wih.GetLength(1); j++)
                {
                    Console.WriteLine("Matrix[" + i + "," + j + "] = " + wih[i, j]);
                }
            }*/
            wih = new double[innodes, hnodes];
            who = new double[hnodes, onodes];
            weightMatr_temp = new double[hnodes, hnodes];
            for (int j = 0; j < hnodes; j++)
                for (int i = 0; i < innodes; i++)
                {
                    System.Random weight_ih = new System.Random(Guid.NewGuid().GetHashCode());
                    wih[i, j] = (weight_ih.NextDouble() - 0.5) * 2.0;
                    // Console.WriteLine("i: " + i + ", j: " + j + ", w: " + wih[i, j].ToString());
                }
            for (int j = 0; j < onodes; j++)
                for (int i = 0; i < hnodes; i++)
                {
                    System.Random weight_ho = new System.Random(Guid.NewGuid().GetHashCode());
                    who[i, j] = (weight_ho.NextDouble() - 0.5) * 2.0;
                    // Console.WriteLine("i: " + i + ", j: " + j + ", w: " + who[i, j].ToString());
                }
                
            //weightList.Add(wih);
            for (int o = 0; o < hiddenLayers; o++)
            {
               for (int j = 0; j < hnodes; j++)
                 {
                 for (int i = 0; i < innodes; i++)
                  {
                   System.Random weight_ih = new System.Random(Guid.NewGuid().GetHashCode());
                   weightMatr_temp[i, j] = (weight_ih.NextDouble() - 0.5) * 2.0;
                 Console.WriteLine("i: " + i + ", j: " + j + ", w: " + wih[i, j].ToString());
                 }
                }
                
                weightList.Add(weightMatr_temp);
            }
            //weightList.Add(who);
        }

        public void queryNN(double[] inputs) 
        {
            hidden_inputs = nnmath.matrixMult(wih, inputs);
            inputList.Add(hidden_inputs);
           
            hidden_outputs = nnmath.sigmoid(hidden_inputs);
            outputList.Add(hidden_outputs);
            int z = 0;
            foreach(double[,] matr in weightList)
            {
                inputList.Add(nnmath.matrixMult(matr, outputList.Last()));
                outputList.Add(nnmath.sigmoid(inputList.Last()));
            }
            final_inputs = nnmath.matrixMult(who, outputList.Last());
            inputList.Add(final_inputs);
            final_outputs = nnmath.sigmoid(inputList.Last());
            outputList.Add(final_outputs);
        }

        public void train(double[] inputs, double[] targets)
        {
            int i;
            double[,] matr_temp;
            this.queryNN(inputs);
            int targNum = targets.GetLength(0);
            output_errors = new double[targNum];
            for(i=0; i < targNum; i++)
            {
                output_errors[i] = targets[i] - outputList.Last()[i];
            }
            errorList.Add(output_errors);

            // output Weights
            // Matrix transponieren
            double[,] whoTrans = nnmath.transpose(who);
            // hidden Error wMatrixT * error
            hidden_errors = nnmath.matrixMult(whoTrans, errorList.Last());
            double[] hefo = nnmath.vectorMult(errorList.Last(), outputList.Last());
            double[] finout = nnmath.vectoradd_sub(1, outputList.Last(), false);
            double[] oefo_temp = nnmath.vectorMult(hefo, finout);
            double[,] errorVec_out = nnmath.matrixMult(oefo_temp, outputList[outputList.Count-1]);
            double[,] deltaW_out = nnmath.matrixScale(errorVec_out, learningRate);
            errorList.Add(hidden_errors);
            who = nnmath.matrixSum(who, deltaW_out);
            //weightList_temp.Add(who);
            int z = 1;
            weightList.Reverse();
            foreach(double[,] matr in weightList)
            {
                double[,] matrTrans = nnmath.transpose(matr);
                hidden_errors = nnmath.matrixMult(matrTrans, errorList.Last());
                hefo = nnmath.vectorMult(errorList.Last(), outputList[outputList.Count-z]);
                finout = nnmath.vectoradd_sub(1, outputList[outputList.Count - z], false);
                oefo_temp = nnmath.vectorMult(hefo, finout);
                errorVec_out = nnmath.matrixMult(oefo_temp, outputList[outputList.Count - (z+1)]);
                deltaW_out = nnmath.matrixScale(errorVec_out, learningRate);
                errorList.Add(hidden_errors);
                matr_temp = nnmath.matrixSum(matr, deltaW_out);
                weightList_temp.Add(matr_temp);
                z++;
            }
            weightList.Clear();
            weightList = weightList_temp;
            weightList_temp.Clear();
            weightList.Reverse();

            // Inputweights
            double[] heho = nnmath.vectorMult(errorList.Last(), outputList[outputList.Count - z]);
            double[] hiout = nnmath.vectoradd_sub(1, outputList[outputList.Count - z], false);
            double[] heho_temp = nnmath.vectorMult(heho, hiout);
            double[,] errorVec_in = nnmath.matrixMult(heho_temp, inputs);
            double[,] deltaW_in = nnmath.matrixScale(errorVec_in, learningRate);
            wih = nnmath.matrixSum(who, deltaW_in);

        }
    }
}
