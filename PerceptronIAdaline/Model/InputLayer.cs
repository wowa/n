using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model
{
    class InputLayer
    {
        public InputLayer(InputNeuron[] inputNeurons)
        {
            inputs = inputNeurons;
        }

        InputNeuron[] inputs;

        public int Size
        {
            get
            {
                return inputs.Length;
            }
        }

        public void SetInput(double[] inputDoubles)
        {
            for (int i = 0; i < Size; i++)
            {
                this[i] = inputDoubles[i];
            }
        }

        public double this[int n]
        {
            get
            {
                return inputs[n].GetSignal();
            }
            set
            {
                inputs[n].SetSignal(value);
            }
        }
    }
}
