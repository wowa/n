using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Interfaces.Pure
{
    interface IAxon
    {
        void ComputeSignal();

        double Signal
        {
            get;
            //set;
        }

        ISoma Soma
        {
            get;
        }


    }
}
