using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Interfaces
{
    using Model.Interfaces;

    interface ISupervisedLearningMethod : ILearningMethod<ISupervisedLearningVector>
    {
        List<Learning.NeuronState> LearningStory
        {
            get;
        }
        double Alpha
        {
            get;
            set;
        }
    }
}
