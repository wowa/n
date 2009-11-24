using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces
{
    public interface Axon
    {
        double GetSignal();
        Soma GetSoma();
    }
}