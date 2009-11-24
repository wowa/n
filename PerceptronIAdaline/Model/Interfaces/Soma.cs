using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces
{
    public interface Soma
    {
        void ComputePotential();
        void ResetPotential();

        void ComputeSignal();
        
        double GetPotential();
        double GetThreshold();

        int GetNoDendrites();
        Dendrite GetDendrite(int n);
        void AddDendrite(Dendrite dendrite);
        void AddDendrites(Dendrite[] dendrites);

     }
}
