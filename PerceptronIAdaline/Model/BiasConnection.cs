using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model
{
    using Interfaces;
    class BiasConnection : NeuralConnection, Axon
    {
        public BiasConnection(double weight)
            : base(weight, null)
        {
            base.axon = this;
        }

        public override double GetSignal()
        {
            return GetWeight();
            // nie ma sensu mnozyc przez zawsze stale 1.0
        }

        public Soma GetSoma()
        {
            throw new NotSupportedException("Can't get soma from Bias");
        }
    }
}
