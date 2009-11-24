using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces.Pure
{
    interface IDendrite
    {
        ISynapse Synapse
        {
            get;
        }

        double Signal
        {
            get;
        }

        ISoma Soma
        {
            get;
        }
    }
}
