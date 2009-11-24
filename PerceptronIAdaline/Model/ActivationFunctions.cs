using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model
{
    public static class ActivationFunctions
    {
        public static double Unipolar(double potential)
        {
            return potential >= .0 ? 1.0 : .0;
        }

        public static double Bipolar(double potential)
        {
            return potential >= .0 ? 1.0 : -1.0;
        }
    }
}
