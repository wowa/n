using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces
{
    interface ILayer
    {
        double[] GetOutput();

        double[] Output
        {
            get;
        }

        INeuron this[int n]
        {
            get;
        }

        void AddNeuron(INeuron neuron);
        void AddNeuronsRange(IEnumerable<INeuron> range);
        void RemoveNeuron(INeuron neuron);

        int NeuronsCount
        {
            get;
        }

        void Compute();
    }
}
