using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model2.Learning.Supervised.Bipolar
{
    using Model2.Interfaces;
    using Model2.Interfaces.Pure;

    class PerceptronLearningMethod : ISupervisedLearningMethod
    {

        double alpha;

        public double Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                alpha = value;
            }
        }

        List<NeuronState> learningStory;
        public List<NeuronState> LearningStory
        {
            get
            {
                return learningStory;
            }
            set
            {
                learningStory = value;
            }
        }

        #region ILearningMethod<ISupervisedLearningVector> Members


        public void Learn(INeuralNetwork net, ILearningSequence<ISupervisedLearningVector> seq)
        {
            LearningStory = new List<NeuronState>();
            bool isLearned = true;

            do
            {
                StoreState(net);
                isLearned = true;
                IEnumerator<ISupervisedLearningVector> en = seq.Vectors.GetEnumerator();
                while (en.MoveNext())
                {
                    net.SetInput(en.Current.Data);

                    net.Compute();

                    double delta = en.Current.CorrectOutput - net[0];
                    if (delta != 0.0)
                    {
                        isLearned = false;
                        CorrectWeights(net, delta > 0 ? 1.0 : -1.0);
                    }
                    
                }
                seq.Shuffle();
                
            } while (!isLearned);
            StoreState(net);
            
        }

        private void StoreState(INeuralNetwork net)
        {
            NeuronState state = new NeuronState();
            INeuron n = net.Layers[1][0];
            state.Inputs = new double[n.NeuralInputs.Count];
            state.Weights = new double[n.NeuralInputs.Count];
            int i = 0;
            foreach (INeuralConnection ni in n.NeuralInputs)
            {
                state.Weights[i] = ni.Weight;
                state.Inputs[i] = ni.Signal;
                i++;
            }
            state.Output = net[0];
            LearningStory.Add(state);
        }

        private void CorrectWeights(INeuralNetwork net, double delta)
        {
            IEnumerator<INeuralConnection> en = net.Layers[1][0].NeuralInputs.GetEnumerator();

            while (en.MoveNext())
            {
                en.Current.Weight = en.Current.Weight + alpha * delta * en.Current.Axon.Signal;
            }
        }

        #endregion
    }
}
