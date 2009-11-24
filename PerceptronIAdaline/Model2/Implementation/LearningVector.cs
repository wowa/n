using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Implementation
{
    using Model2.Interfaces;

    class LearningVector : ILearningVector
    {
        double[] data;

        public LearningVector(IEnumerable<double> vector)
        {
            data = vector.ToArray();
        }

        public double this[int n]
        {
            get
            {
                return data[n];
            }
        }

        public int Length
        {
            get
            {
                return data.Length;
            }
        }

        #region ILearningVector Members

        public double[] Data
        {
            get { return data; }
        }

        #endregion

        #region IEnumerable<double> Members

        public IEnumerator<double> GetEnumerator()
        {
            return data.AsEnumerable<double>().GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        #endregion
    }
}
