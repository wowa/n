﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces
{
    using Interfaces;
    interface IInputLayer : ILayer
    {
        void SetOutput(double[] vector);
        new double[] Output
        {
            get;
            set;
        }
    }
}
