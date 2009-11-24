using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Implementation
{
    using Model2.Interfaces;
    using Model2.Interfaces.Pure;

    public delegate double ActivationFunction(double potential);

    class Neuron : INeuron
    {
        public static double UnipolarActivationFunction(double potential)
        {
            return potential >= 0 ? 1 : 0;
        }

        public static double BipolarActivationFunction(double potential)
        {
            return potential >= 0 ? 1 : -1;
        }

        public static double UnipolarSigmoidalActivationFunction(double potential)
        {
            const double beta = 1.0d;
            double signal = 1.0d / (1 + Math.Exp(-beta * potential));
            return signal;
        }

        public static double BipolarSigmoidalActivationFunction(double potential)
        {
            const double beta = 1.0d;
            double signal = Math.Tanh(beta * potential);
            return signal;
        }

        double signal = .0d, potential = .0d;

        List<INeuralConnection> inputConnections = new List<INeuralConnection>(),
            outputConnections = new List<INeuralConnection>();

        public Neuron()
        { }

        public Neuron(ActivationFunction activationFunction)
        {
            this.activationFunction = activationFunction;
        }
        
        ActivationFunction activationFunction;



        #region INeuron Members

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

        public IList<INeuralConnection> NeuralInputs
        {
            get
            {
                return (IList<INeuralConnection>)inputConnections.AsReadOnly();
            }
        }

        public IList<INeuralConnection> NeuralOutputs
        {
            get
            {
                return (IList<INeuralConnection>)outputConnections.AsReadOnly();
            }
        }
        public void AddNeuralInput(INeuralConnection conn)
        {
            if (!inputConnections.Contains(conn))
            {
                if (conn.Destination != this)
                    conn.Destination = this;

                inputConnections.Add(conn);
            }
        }

        public void RemoveNeuralInput(INeuralConnection conn)
        {
            if (conn.Destination == this)
                conn.Destination = null;

            inputConnections.Remove(conn);
        }

        public void AddNeuralOutput(INeuralConnection conn)
        {
            if (conn.Source != this)
                conn.Source = this;

            outputConnections.Add(conn);
        }

        public void RemoveNeuralOutput(INeuralConnection conn)
        {
            if (conn.Source == this)
                conn.Destination = null;
            inputConnections.Remove(conn);
        }

        #endregion

        #region ISoma Members

        public void ComputePotential()
        {
            potential = inputConnections.Sum(dendrite => dendrite.Signal);
        }

        public IAxon Axon
        {
            get { return (IAxon)this; }
        }

        public IList<IDendrite> Dendrites
        {
            get { return (IList<IDendrite>)inputConnections.Cast<IDendrite>().ToList().AsReadOnly(); }
        }

        public double Potential
        {
            get { return potential; }
        }

        #endregion

        #region IAxon Members

        public void ComputeSignal()
        {
            if (activationFunction != null)
                signal = activationFunction(Potential);
        }

        public ISoma Soma
        {
            get { return (ISoma)this; }
        }

        #endregion

    }
}
