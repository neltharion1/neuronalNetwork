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
        private int hnodes, innodes, onodes;
        private double[,] who, wih;
        private double learningRate;
        private double[] output_errors;
        private nnMath nnmath = new nnMath();


        public double[] Final_inputs { get { return final_inputs; } set { final_inputs = value; } }
        public double[] Final_outputs { get { return final_outputs; } set { final_outputs = value; } }
        public double[] Hidden_inputs { get { return hidden_inputs; } set { hidden_inputs = value; } }
        public double[] Hidden_outputs { get { return hidden_outputs; } set { hidden_outputs = value; } }
        public double[] Hidden_errors { get { return hidden_errors; } set { hidden_errors = value; } }
        public double[] Output_errors { get { return output_errors; } set { output_errors = value; } }
        public double[,] WHO { get { return who; } }
        public double[,] WIH { get { return wih; } }
        public nn3S(int innodes, int hnodes, int onodes, double learningRate)
        {
            this.innodes = innodes;
            this.hnodes = hnodes;
            this.onodes = onodes;
            this.learningRate = learningRate;
            createWeightMatrizes();
        }

        private void createWeightMatrizes()
        {
            wih = new double[,]{ { 0.9, 0.3, 0.4 }, { 0.2, 0.8, 0.2 }, { 0.1,0.5,0.6} };
            who = new double[,] { { 0.3, 0.7, 0.5 }, { 0.6, 0.5, 0.2 }, { 0.8, 0.1, 0.9 } };
            for(int i =0; i< wih.GetLength(0); i++)
            {
                for(int j = 0; j < wih.GetLength(1); j++)
                {
                    Console.WriteLine("Matrix[" + i + "," + j + "] = " + wih[i, j]);
                }
            }
        }

        public void queryNN(double[] inputs) 
        {
            hidden_inputs = nnmath.matrixMult(wih, inputs);
            //hidden_outputs = new double[hidden_inputs.GetLength(0)];
            for(int i=0; i<hidden_inputs.GetLength(0); i++)
            {
                Console.WriteLine("HiddenInput[" + i + "] = " + hidden_inputs[i]);                
            }
            hidden_outputs = nnmath.sigmoid(hidden_inputs);
            final_inputs = nnmath.matrixMult(who, hidden_outputs);
            final_outputs = nnmath.sigmoid(final_inputs);
        }

        public void train(double[] inputs, double[] targets)
        {
            int i;
            this.queryNN(inputs);
            int targNum = targets.GetLength(0);
            output_errors = new double[targNum];
            for(i=0; i < targNum; i++)
            {
                output_errors[i] = targets[i] - final_outputs[i];
            }

            // output Weights
            double[,] whoTrans = nnmath.transpose(who);
            hidden_errors = nnmath.matrixMult(whoTrans, output_errors);
            double[] hefo = nnmath.vectorMult(output_errors, final_outputs);
            double[] finout = nnmath.vectoradd_sub(1, final_outputs, false);
            double[] oefo_temp = nnmath.vectorMult(hefo, finout);
            double[,] errorVec_out = nnmath.matrixMult(oefo_temp, hidden_outputs);
            double[,] deltaW_out = nnmath.matrixScale(errorVec_out, learningRate);
            who = nnmath.matrixSum(who, deltaW_out);

            // Inputweights
            double[] heho = nnmath.vectorMult(hidden_errors, hidden_outputs);
            double[] hiout = nnmath.vectoradd_sub(1, hidden_outputs, false);
            double[] heho_temp = nnmath.vectorMult(heho, hiout);
            double[,] errorVec_in = nnmath.matrixMult(heho_temp, inputs);
            double[,] deltaW_in = nnmath.matrixScale(errorVec_in, learningRate);
            wih = nnmath.matrixSum(who, deltaW_in);

        }
    }
}
