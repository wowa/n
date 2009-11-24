using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Interfaces
{
    interface ISupervisedLearningVector : ILearningVector
    {
        double CorrectOutput
        {
            get;
        }
    }
}
