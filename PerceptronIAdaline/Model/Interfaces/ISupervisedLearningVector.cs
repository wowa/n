using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces
{
    interface ISupervisedLearningVector : ILearningVector
    {
        double CorrectOutput
        {
            get;
        }
    }
}
