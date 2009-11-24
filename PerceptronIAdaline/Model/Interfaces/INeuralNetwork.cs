using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces
{
    interface INeuralNetwork
    {
        double this[int n]
        {
            get;
            set;
        }

        void SetInput(double[] input);
        double[] GetOutput();
        void Compute();

        IList<ILayer> Layers
        {
            get;
        }

        int InputCount
        {
            get;
        }

        int OutputCount
        {
            get;
        }


    }
}
