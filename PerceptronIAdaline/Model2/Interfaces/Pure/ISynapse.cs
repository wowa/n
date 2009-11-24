﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Interfaces.Pure
{
    interface ISynapse
    {
        IAxon Axon
        {
            get;
        }

        double Weight
        {
            get;
            //set;
        }
    }
}
