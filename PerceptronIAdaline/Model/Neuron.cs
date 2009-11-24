using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model
{
    using Interfaces;

    public delegate double ActivationFunction(double potential);

    public abstract class Neuron : Soma, Axon
    {
        Dendrite[] dendrites;
        double potential, signal;

        public Neuron()
        {
            dendrites = new Dendrite[1] { new BiasConnection(0.1) };
        }

        ActivationFunction activationFunction;

        public void SetActivationFunction(ActivationFunction activationFunction)
        {
            this.activationFunction = activationFunction;
        }

        public void ComputePotential()
        {
            potential = dendrites.Sum(s => s.GetSignal());
        }

        public void ResetPotential()
        {
            potential = .0d;
        }

        public void ComputeSignal()
        {
            signal = activationFunction(potential);
        }

        public double GetPotential()
        {
            return potential;
        }

        public double GetThreshold()
        {
            return dendrites[0].GetSynapse().GetWeight();
        }

        public double GetSignal()
        {
            return signal;
        }

        public void AddDendrite(Dendrite dendrite)
        {
            Dendrite[] dnds = new Dendrite[1] { dendrite };
            dendrites = (Dendrite[])dendrites.Concat(dnds).ToArray();
        }
        public void AddDendrites(Dendrite[] dendrites)
        {
            for (int i = 0; i < dendrites.Length; i++)
                AddDendrite(dendrites[i]);
        }

        public int GetNoDendrites()
        {
            return dendrites.Length - 1;
        }

        public Dendrite GetDendrite(int n)
        {
            return dendrites[n+1];
        }

        public Axon GetAxon()
        {
            return this;
        }

        public Soma GetSoma()
        {
            return this;
        }
    }
}