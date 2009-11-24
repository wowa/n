using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces
{
    public interface Synapse
    {
        double GetWeight();
        void ChangeWeight(double weight);
        Axon GetAxon();
    }
}
