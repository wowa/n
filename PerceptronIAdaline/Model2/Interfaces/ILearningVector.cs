using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Interfaces
{
    interface ILearningVector : IEnumerable<double>
    {
        double this[int n]
        {
            get;
        }

        int Length
        {
            get;
        }

        double[] Data
        {
            get;
        }

    }
}
