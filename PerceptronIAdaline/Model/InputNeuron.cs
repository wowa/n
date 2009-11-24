using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model
{
    using Interfaces;
    class InputNeuron : Axon
    {
        double signal;

        public double Signal
        {
            get
            {
                return signal;
            }
            set
            {
                signal = value;
            }
        }

        public void SetSignal(double signal)
        {
            this.signal = signal;
        }

        public double GetSignal()
        {
            return signal;
        }

        public Soma GetSoma()
        {
            throw new NotSupportedException("Can't get soma from Input Neuron");
        }
    }
}
