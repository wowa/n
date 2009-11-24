using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces
{
    using Pure;
    interface INeuralConnection : ISynapse, IDendrite
    {
        new double Weight
        {
            get;
            set;
        }

        INeuron Source
        {
            get;
            set;
        }

        INeuron Destination
        {
            get;
            set;
        }
    }
}
