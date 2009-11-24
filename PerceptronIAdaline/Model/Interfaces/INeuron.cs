using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces
{
    using Pure;
    interface INeuron : ISoma, IAxon
    {
        double Signal
        {
            get;
            set;
        }

        void AddNeuralInput(INeuralConnection conn);
        void RemoveNeuralInput(INeuralConnection conn);
        void AddNeuralOutput(INeuralConnection conn);
        void RemoveNeuralOutput(INeuralConnection conn);

        IList<INeuralConnection> NeuralInputs
        {
            get;
        }

        // to bedzie hardcore :) ale zrobie
        IList<INeuralConnection> NeuralOutputs
        {
            get;
        }
    }
}