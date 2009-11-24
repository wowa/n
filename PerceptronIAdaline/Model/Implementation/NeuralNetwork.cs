using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronIAdaline.Model.Implementation
{
    using Interfaces;
    class NeuralNetwork : INeuralNetwork
    {
        List<ILayer> layers;
        IInputLayer inputLayer;
        ILayer outputLayer;

        public NeuralNetwork()
        {
            layers = new List<ILayer>();
        }

        public IList<ILayer> Layers
        {
            get
            {
                
                return layers.AsReadOnly();
            }
        }
        bool isBipolar;

        public void Build(int inputsCount, 
            int[] hiddenLayersSpec, 
            int outputsCount, 
            ActivationFunction activationFunction,
            double maximumAbsoluteWeight)
        {
            layers = new List<ILayer>();
            inputLayer = new InputLayer();
            for (int i = 0; i < inputsCount; i++)
                inputLayer.AddNeuron(new Neuron());

            isBipolar = activationFunction == Neuron.BipolarActivationFunction;
            layers.Add((Layer)inputLayer);

            if (hiddenLayersSpec != null)
                for (int i = 0; i < hiddenLayersSpec.Length; i++)
                {
                    ILayer layer = new Layer();
                    for (int j = 0; j < hiddenLayersSpec[i]; j++)
                    {
                        layer.AddNeuron(new Neuron(activationFunction));
                    }
                    layers.Add(layer);
                }

            outputLayer = new Layer();
            for (int i = 0; i < outputsCount; i++)
            {
                outputLayer.AddNeuron(new Neuron(activationFunction));
            }
            layers.Add(outputLayer);

            ConnectLayers(maximumAbsoluteWeight);
        }

        private void ConnectLayers(double maximumAbsoluteWeight)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            
            for (int i = 1; i < layers.Count; i++)
            {
                for (int j = 0; j < layers[i].NeuronsCount; j++)
                {
                    for (int k = 0; k < layers[i-1].NeuronsCount; k++)
                    {
                        NeuralConnection nc = new NeuralConnection(layers[i - 1][k], layers[i][j]);
                        if (isBipolar)
                            nc.Weight = rand.NextDouble() * maximumAbsoluteWeight * (rand.Next(1) == 1 ? 1 : -1);
                        else
                            nc.Weight = rand.NextDouble() * maximumAbsoluteWeight;
                    }
                    Neuron n = new Neuron();
                    n.Signal = 1.0;
                    
                    NeuralConnection na = new NeuralConnection(n, layers[i][j]);
                    if (isBipolar)
                        na.Weight = rand.NextDouble() * maximumAbsoluteWeight * (rand.Next(1) == 1 ? 1 : -1);
                    else
                        na.Weight = rand.NextDouble() * maximumAbsoluteWeight;
                }
            }
        }

        #region INeuralNetwork Members

        public double this[int n]
        {
            get
            {
                return layers[layers.Count - 1][n].Signal;
            }
            set
            {
                layers[layers.Count - 1][n].Signal = value;
            }
        }

        public void SetInput(double[] input)
        {
            ((IInputLayer)layers[0]).Output = input;
        }

        public double[] GetOutput()
        {
            return layers[layers.Count - 1].Output;
        }

        public int InputCount
        {
            get { throw new NotImplementedException(); }
        }

        public int OutputCount
        {
            get { throw new NotImplementedException(); }
        }

        public void Compute()
        {
            IEnumerator<ILayer> en = layers.GetEnumerator();
            while (en.MoveNext())
            {
                en.Current.Compute();
            }
        }

        #endregion
    }
}
