using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces
{
    interface ILearningMethod<T>
    {
        void Learn(INeuralNetwork net, ILearningSequence<T> seq);
    }
}
