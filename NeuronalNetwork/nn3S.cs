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
        public double[,] WHO { get { return who; } set { who = value; } }
        public double[,] WIH { get { return wih; }set { wih = value; } }
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

        public void createFromData(int innodes, int hnodes, int onodes, int hiddenLayers)
        {
            this.innodes = innodes;
            this.hnodes = hnodes;
            this.onodes = onodes;
            this.hiddenLayers = hiddenLayers;
            wih = new double[hnodes, innodes];
            who = new double[onodes, hnodes];
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
            wih = new double[hnodes, innodes];
            who = new double[onodes, hnodes];
           // Console.WriteLine("create wih[" + wih.GetLength(0) + "," + wih.GetLength(1) + "]");
           // Console.WriteLine("create who[" + who.GetLength(0) + "," + who.GetLength(1) + "]");
            //weightMatr_temp = new double[hnodes, hnodes];
            for (int i = 0; i < hnodes; i++)
                for (int j = 0; j < innodes; j++)
                {
                    System.Random weight_ih = new System.Random(Guid.NewGuid().GetHashCode());
                    wih[i, j] = (weight_ih.NextDouble() - 0.5) * 2.0;
                     //Console.WriteLine("i: " + i + ", j: " + j + ", w: " + wih[i, j].ToString());
                }
            for (int i = 0; i < onodes; i++)
                for (int j = 0; j < hnodes; j++)
                {
                    System.Random weight_ho = new System.Random(Guid.NewGuid().GetHashCode());
                    who[i, j] = (weight_ho.NextDouble() - 0.5) * 2.0;
                    // Console.WriteLine("i: " + i + ", j: " + j + ", w: " + who[i, j].ToString());
                }
            
            //weightList.Add(wih);
            for (int o = 0; o < hiddenLayers; o++)
            {
                weightMatr_temp = new double[hnodes, hnodes];
                for (int i = 0; i < hnodes; i++)
                 {
                 for (int j = 0; j < hnodes; j++)
                  {
                    System.Random weight_hh = new System.Random(Guid.NewGuid().GetHashCode());
                    weightMatr_temp[i, j] = (weight_hh.NextDouble() - 0.5) * 2.0;
                    //Console.WriteLine("i: " + i + ", j: " + j + ", w: " + wih[i, j].ToString());
                 }
                }               
                weightList.Add(weightMatr_temp);
                weightList_temp.Clear();
            }
            //weightList.Add(who);
        }

        public void queryNN(double[] inputs) 
        {
            
            //Console.WriteLine("query0: inputs[" + inputs.GetLength(0)+"]");
            hidden_inputs = nnmath.matrixMult(wih, inputs);
            //Console.WriteLine("queryNN 1 hiddeninputs["+hidden_inputs.GetLength(0)+"]");
            inputList.Add(hidden_inputs);
           
            hidden_outputs = nnmath.sigmoid(hidden_inputs);
            outputList.Add(hidden_outputs);
            //Console.WriteLine("queryNN 2 hiddenoutputs[" + hidden_outputs.GetLength(0) + "]");
            int z = 0;
            foreach(double[,] matr in weightList)
            {
                inputList.Add(nnmath.matrixMult(matr, outputList.Last()));
                outputList.Add(nnmath.sigmoid(inputList.Last()));
            }

            final_inputs = nnmath.matrixMult(who, outputList.Last());
            //Console.WriteLine("queryNN 3 final_inputs["+final_inputs.GetLength(0)+"]");
            inputList.Add(final_inputs);
            final_outputs = nnmath.sigmoid(inputList.Last());
            outputList.Add(final_outputs);
            //Console.WriteLine("queryNN 3 final_outputs[" + final_outputs.GetLength(0) + "]");
        }

        public void train(double[] inputs, double[] targets)
        {
            //Console.WriteLine("train0 inputs[" + inputs.GetLength(0) + "]");
            int i;
            double[,] matr_temp;
            this.queryNN(inputs);
            //Console.WriteLine("train 1");
            int targNum = targets.GetLength(0);
            output_errors = new double[targNum];
            for(i=0; i < targNum; i++)
            {
                output_errors[i] = targets[i] - outputList.Last()[i];
            }
            errorList.Add(output_errors);
            //Console.WriteLine("train 2 output_errors["+output_errors.GetLength(0)+"]");
            // output Weights
            // Matrix transponieren
            double[,] whoTrans = nnmath.transpose(who);
            //Console.WriteLine("train 3 whotrans["+ whoTrans.GetLength(0)+","+ whoTrans.GetLength(1)+"]");
            // hidden Error wMatrixT * error
            hidden_errors = nnmath.matrixMult(whoTrans, errorList.Last());
            //Console.WriteLine("train 4 output_errors[" + output_errors.GetLength(0) + "]");
            double[] hefo = nnmath.vectorMult(errorList.Last(), outputList.Last());
            //Console.WriteLine("train 5 hefo["+hefo.GetLength(0)+"]");
            double[] finout = nnmath.vectoradd_sub(1, outputList.Last(), false);
            //Console.WriteLine("train 6 finout["+finout.GetLength(0)+"]");
            double[] oefo_temp = nnmath.vectorMult(hefo, finout);
            //Console.WriteLine("train 7 oefo_temp["+ oefo_temp.GetLength(0)+"]");
            double[,] errorVec_out = nnmath.matrixMult(oefo_temp, outputList[outputList.Count-2]);
            //Console.WriteLine("train 8 errorVec_out["+ errorVec_out.GetLength(0)+","+ errorVec_out.GetLength(1) + "]");
            double[,] deltaW_out = nnmath.matrixScale(errorVec_out, learningRate);
            //Console.WriteLine("train 9 deltaW_out["+ deltaW_out.GetLength(0)+","+ deltaW_out.GetLength(1)+"]");
            errorList.Add(hidden_errors);
            who = nnmath.matrixSum(who, deltaW_out);
            //Console.WriteLine("train 10 who["+who.GetLength(0)+","+ who.GetLength(1)+"]");
            //weightList_temp.Add(who);
            int z = 1;
            weightList.Reverse();
            foreach(double[,] matr in weightList)
            {
                double[,] matrTrans = nnmath.transpose(matr);
                //Console.WriteLine("foreach: train 1 matrTrans[" + matrTrans.GetLength(0) + "," + matrTrans.GetLength(1) + "]");
                hidden_errors = nnmath.matrixMult(matrTrans, errorList.Last());
                //Console.WriteLine("foreach: train 2 hidden_errors[" + hidden_errors.GetLength(0) + "]");
                hefo = nnmath.vectorMult(errorList.Last(), outputList[outputList.Count-(1+z)]);
                //Console.WriteLine("foreach: train 3 hefo[" + hefo.GetLength(0) + "]");
                finout = nnmath.vectoradd_sub(1, outputList[outputList.Count - (1+z)], false);
                //Console.WriteLine("foreach: train 4 finout[" + finout.GetLength(0) + "]");
                oefo_temp = nnmath.vectorMult(hefo, finout);
                //Console.WriteLine("foreach: train 5 oefo_temp[" + oefo_temp.GetLength(0) + "]");
                errorVec_out = nnmath.matrixMult(oefo_temp, outputList[outputList.Count - (z+1)]);
                //Console.WriteLine("foreach: train 6 errorVec_out[" + errorVec_out.GetLength(0) + "," + errorVec_out.GetLength(1) + "]");
                deltaW_out = nnmath.matrixScale(errorVec_out, learningRate);
                //Console.WriteLine("foreach: train 7 deltaW_out[" + deltaW_out.GetLength(0) + "," + deltaW_out.GetLength(1) + "]");
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
            //Console.WriteLine("train 11 outputlist.count: "+ outputList.Count());
            double[] heho = nnmath.vectorMult(errorList.Last(), outputList[outputList.Count - (1+z)]);
            //Console.WriteLine("train 12");
            double[] hiout = nnmath.vectoradd_sub(1, outputList[outputList.Count - (1+z)], false);
            //Console.WriteLine("train 13");
            double[] heho_temp = nnmath.vectorMult(heho, hiout);
            //Console.WriteLine("train 14");
            double[,] errorVec_in = nnmath.matrixMult(heho_temp, inputs); 
            //Console.WriteLine("train 15");
            double[,] deltaW_in = nnmath.matrixScale(errorVec_in, learningRate);
            //Console.WriteLine("train 16");
            wih = nnmath.matrixSum(wih, deltaW_in);
            //Console.WriteLine("train 17");

            errorList.Clear();
            inputList.Clear();
            outputList.Clear();
        }
    }
}
