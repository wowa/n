using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Interfaces.Pure
{
    interface ISoma
    {
        void ComputePotential();

        IAxon Axon
        {
            get;
        }

        IList<IDendrite> Dendrites
        {
            get;
        }

        double Potential
        {
            get;
            //set;
        }
    }
}
