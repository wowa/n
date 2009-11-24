using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Implementation
{
    using Model2.Interfaces;

    class LearningSequence<T> : ILearningSequence<T>
    {
        List<T> vectors;

        public LearningSequence(IEnumerable<T> init)
        {
            vectors = init.ToList<T>();
        }

        public LearningSequence()
        {
            vectors = new List<T>();
        }

        public void Add(T v)
        {
            vectors.Add(v);
        }

        public T this[int n]
        {
            get
            {
                return vectors[n];
            }
        }

        public int Length
        {
            get
            {
                return vectors.Count;
            }
        }

        #region ILearningSequence<T> Members

        public IList<T> Vectors
        {
            get { return vectors.AsReadOnly(); }
        }

        public void Shuffle()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);

            for (int i = rand.Next(vectors.Count); i-- > 0; )
            {
                int j = rand.Next(vectors.Count);
                T tmp = vectors[j];
                vectors[j] = vectors[i];
                vectors[i] = tmp;
            }
        }

        #endregion
    }
}
