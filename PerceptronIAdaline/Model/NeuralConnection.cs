using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model
{
    using Interfaces;

    class NeuralConnection : Synapse, Dendrite
    {
        double weight;
        protected Axon axon;

        public NeuralConnection(double weight, Axon axon)
        {
            this.weight = weight;
            this.axon = axon;
        }

        public virtual double GetSignal()
        {
            return weight * axon.GetSignal();
        }

        public void ChangeWeight(double change)
        {
            weight += change;
        }

        public double GetWeight()
        {
            return weight;
        }

        public Axon GetAxon()
        {
            return axon;
        }

        public Synapse GetSynapse()
        {
            return this;
        }
    }
}
