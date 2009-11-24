using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Implementation
{
    using Interfaces;
    class Layer : ILayer
    {
        List<INeuron> list;

        public Layer()
        {
            list = new List<INeuron>();
        }

        public Layer(IEnumerable<INeuron> neurons)
        {
            list = new List<INeuron>(neurons);
        }

        #region ILayer Members

        public INeuron this[int n]
        {
            get { return list[n]; }
        }

        public int NeuronsCount
        {
            get { return list.Count; }
        }

        public void AddNeuron(INeuron neuron)
        {
            list.Add(neuron);
        }

        public void AddNeuronsRange(IEnumerable<INeuron> range)
        {
            list.AddRange(range);
        }

        public void RemoveNeuron(INeuron neuron)
        {
            list.Remove(neuron);
        }

        public double[] GetOutput()
        {
            return list.Select(axon => axon.Signal).ToArray();
        }

        public double[] Output
        {
            get { return GetOutput(); }
        }

        public void Compute()
        {
            IEnumerator<INeuron> en = list.GetEnumerator();

            while (en.MoveNext())
            {
                en.Current.ComputePotential();
                en.Current.ComputeSignal();
            }
        }

        #endregion
    }
}
