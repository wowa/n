using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Interfaces
{
    interface ILearningSequence<T>
    {
        IList<T> Vectors
        {
            get;
        }

        void Shuffle();
        void Add(T v);

        T this[int n]
        {
            get;
        }

        int Length
        {
            get;
        }
    }
}
