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
        private double[][] who, wih;

        public nn3S(int innodes, int hnodes, int onodes)
        {
            this.innodes = innodes;
            this.hnodes = hnodes;
            this.onodes = onodes;
        }


    }
}
