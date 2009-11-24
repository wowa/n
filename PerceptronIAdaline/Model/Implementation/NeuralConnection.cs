using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Implementation
{
    using Interfaces;
    using Interfaces.Pure;
    class NeuralConnection : INeuralConnection
    {
        double weight = .0d;
        INeuron source = null, destination = null;

        public NeuralConnection()
        { }

        public NeuralConnection(INeuron source, INeuron destination)
        {
            Source = source;
            Destination = destination;
            //source.AddNeuralOutput(this);
            //destination.AddNeuralInput(this);
        }

        #region INeuralConnection Members

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        public INeuron Source
        {
            get
            {
                return source;
            }
            set
            {
                if (source != null)
                {
                    source.RemoveNeuralOutput(this);
                }
                source = value;

                if (value != null)
                {
                    value.AddNeuralOutput(this);
                }
            }
        }

        public INeuron Destination
        {
            get
            {
                return destination;
            }
            set
            {

                if (destination != null)
                {
                    destination.RemoveNeuralInput(this);
                }
                destination = value;

                if (value != null)
                {
                    value.AddNeuralInput(this);
                }
            }
        }

        #endregion

        #region ISynapse Members

        public IAxon Axon
        {
            get { return (IAxon)source; }
        }

        #endregion

        #region IDendrite Members

        public ISynapse Synapse
        {
            get { return (ISynapse)this; }
        }

        public double Signal
        {
            get { return source.Signal * Weight; }
        }

        public ISoma Soma
        {
            get { return (ISoma)source; }
        }

        #endregion
    }
}
