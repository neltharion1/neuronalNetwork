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
        private int hnodes, innodes, onodes;
        private double[,] who, wih;
        private nnMath nnmath = new nnMath();

        public double[] Final_inputs { get { return final_inputs; } set { final_inputs = value; } }
        public double[] Final_outputs { get { return final_outputs; } set { final_outputs = value; } }
        public double[] Hidden_inputs { get { return hidden_inputs; } set { hidden_inputs = value; } }
        public double[] Hidden_outputs { get { return hidden_outputs; } set { hidden_outputs = value; } }

        public nn3S(int innodes, int hnodes, int onodes)
        {
            this.innodes = innodes;
            this.hnodes = hnodes;
            this.onodes = onodes;
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
            hidden_inputs = nnmath.matixMultVec(wih, inputs);
            //hidden_outputs = new double[hidden_inputs.GetLength(0)];
            for(int i=0; i<hidden_inputs.GetLength(0); i++)
            {
                Console.WriteLine("HiddenInput[" + i + "] = " + hidden_inputs[i]);                
            }
            hidden_outputs = nnmath.sigmoid(hidden_inputs);
            final_inputs = nnmath.matixMultVec(who, hidden_outputs);
            final_outputs = nnmath.sigmoid(final_inputs);
        }
    }
}
