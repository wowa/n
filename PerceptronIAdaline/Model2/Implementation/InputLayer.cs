using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Implementation
{
    using Interfaces;
    class InputLayer : Layer, IInputLayer
    {
        #region IInputLayer Members

        public void SetOutput(double[] vector)
        {
            for (int i = 0; i < base.NeuronsCount && i < vector.Length; i++)
            {
                base[i].Signal = vector[i];
            }
        }

        public new double[] Output
        {
            get
            {
                return base.GetOutput();
            }
            set
            {
                SetOutput(value);
            }
        }

        #endregion
    }
}
