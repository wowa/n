﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Implementation
{
    using Model.Interfaces;

    class SupervisedLearningVector : LearningVector, ISupervisedLearningVector
    {
        double output;

        public SupervisedLearningVector(IEnumerable<double> vector, double correctOutput)
            : base(vector)
        {
            
            output = correctOutput;
        }

        public double CorrectOutput
        {
            get
            {
                return output;
            }
        }

    }
}
