using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Learning
{
    class LearningVector
    {
        public LearningVector(double[] data)
        {
            vector = data;
        }

        double[] vector;
        int inputSize;

        public double this[int n]
        {
            get
            {
                return vector[n];
            }
            set
            {
                vector[n] = value;
            }
        }

        public double[] Vector
        {
            get
            {
                return vector;
            }
        }

        public int Size
        {
            get
            {
                return vector.Length;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('|');
            for (int i = 0; i < vector.Length; i ++)
            {
                string number = string.Format("{0:0.0}", vector[i]);

                string cell = string.Format(" {0:-3} |", number);
                sb.Append(cell);
            }
            return sb.ToString();
        }
    }
}
