using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PerceptronIAdaline
{
    using Model.Implementation;
    using Model.Learning.Supervised.Bipolar;
    using Model.Learning.Supervised;
    using Model.Interfaces;
    class Program
    {

        static StringBuilder sb = new StringBuilder();

        static void BigTest()
        {
            LearningSequence<ISupervisedLearningVector> band = new LearningSequence<ISupervisedLearningVector>();
            band.Add(new SupervisedLearningVector(new double[2] { -1, -1 }, -1));
            band.Add(new SupervisedLearningVector(new double[2] { 1, -1 }, -1));
            band.Add(new SupervisedLearningVector(new double[2] { -1, 1 }, -1));
            band.Add(new SupervisedLearningVector(new double[2] { 1, 1 }, 1));

            LearningSequence<ISupervisedLearningVector> bor = new LearningSequence<ISupervisedLearningVector>();
            bor.Add(new SupervisedLearningVector(new double[2] { -1, -1 }, -1));
            bor.Add(new SupervisedLearningVector(new double[2] { 1, -1 }, 1));
            bor.Add(new SupervisedLearningVector(new double[2] { -1, 1 }, 1));
            bor.Add(new SupervisedLearningVector(new double[2] { 1, 1 }, 1));
            
            LearningSequence<ISupervisedLearningVector> uand = new LearningSequence<ISupervisedLearningVector>();
            uand.Add(new SupervisedLearningVector(new double[2] { 0, 0 }, 0));
            uand.Add(new SupervisedLearningVector(new double[2] { 1, 0 }, 0));
            uand.Add(new SupervisedLearningVector(new double[2] { 0, 1 }, 0));
            uand.Add(new SupervisedLearningVector(new double[2] { 1, 1 }, 1));

           LearningSequence<ISupervisedLearningVector> uor = new LearningSequence<ISupervisedLearningVector>();
            uor.Add(new SupervisedLearningVector(new double[2] { 0, 0 }, 0));
            uor.Add(new SupervisedLearningVector(new double[2] { 1, 0 }, 1));
            uor.Add(new SupervisedLearningVector(new double[2] { 0, 1 }, 1));
            uor.Add(new SupervisedLearningVector(new double[2] { 1, 1 }, 1));


            sb.AppendLine("%Dla matlaba :)");
            sb.AppendLine("% Perceptron prosty!");
            sb.AppendLine("%Zaleznosc efektywnosci od wag");
            sb.AppendLine("%Bipolarny - AND");

            int K = 1000;
            double ALPHA = 0.8;
            double WEIGHT = 0.1;

            PerceptronLearningMethod plm = new PerceptronLearningMethod();
            plm.Alpha = ALPHA;
            
            double[] wagi = new double[] { 5, 4,3,2, 1.0, 0.9, 0.8, 0.7, 0.6, 0.5, .4, .3,.2,.1,.0};

            sb.Append("weights_avg_noepoch_test_uniand_alpha02_k"+K+" = [");
            for (int i = 0; i < wagi.Length; i++)
            {

                sb.Append(wagi[i] + " "
                    + testLearn(plm, uand, Neuron.UnipolarActivationFunction, K, wagi[i])
                    + ";");
            }
            sb.AppendLine();

            sb.Append("weights_avg_noepoch_test_biand_alpha02_k"+K+" = [");
            for (int i = 0; i < wagi.Length; i++)
            {
                sb.Append(wagi[i] + " " 
                    + testLearn(plm, band, Neuron.BipolarActivationFunction, K, wagi[i]) 
                    + ";");

            }
            sb.AppendLine();


            sb.AppendLine("%Zaleznosc efektywnosci od alpha");
            double[] alfy = new double[] { 64,32, 16,8,4,2,1,.9,.8,.7,.6,.5, .4, .3, .2, .1, .09, .08, .07, .06, .05, .04, .03, .02, .01, .001 };
            sb.Append("alpha_avg_noepoch_test_uniand_k"+K+"=[");
            for (int i = 0; i < alfy.Length; i++)
            {
                plm.Alpha = alfy[i];
                sb.Append(alfy[i] + " "
                    + testLearn(plm, uand, Neuron.UnipolarActivationFunction, K, WEIGHT)
                    + ";");
            }
            sb.AppendLine();

            sb.Append("alpha_avg_noepoch_test_band_k"+K+"=[");
            for (int i = 0; i < alfy.Length; i++)
            {
                plm.Alpha = alfy[i];
                sb.Append(alfy[i] + " "
                    + testLearn(plm, band, Neuron.BipolarActivationFunction, K, WEIGHT)
                    + ";");
            }
            sb.AppendLine();
            
            Console.WriteLine(sb.ToString());
            
            /*

            LearningSequence<ISupervisedLearningVector> klocki = new LearningSequence<ISupervisedLearningVector>();

            // kolumny seria 1 zamalowane, seria 2 niezamalowane
            // kolejno kwadraty i kola -> duzy, maly
            double[][] aa = new double[20][]
            //                     zamalowane |  niezamalowane
            {          ///     dk  mk  do  mo  dk  mk  do  mo
                new double[] {  1, -1,  1,  1,  1,  1,  1,  1 },
                new double[] { -1, -1,  1,  1,  1, -1, -1,  1 },
                new double[] {  1,  1,  1,  1,  1,  1,  1,  1 },
                new double[] {  1, -1,  1, -1,  1, -1,  1, -1 },
                new double[] {  1,  1,  1,  1,  1,  1,  1,  1 },
                new double[] { -1, -1,  1,  1,  1, -1, -1,  1 },
                new double[] { -1,  1,  1, -1,  1, -1,  1, -1 },
                new double[] {  1,  1,  1,  1,  1,  1,  1, -1 },
                new double[] { -1, -1,  1, -1,  1,  1, -1, -1 },
                new double[] { -1,  1,  1,  1,  1, -1, -1,  1 },

                new double[] { -1,  1,  1, -1, -1,  1,  1, -1 },
                new double[] { -1, -1,  1, -1, -1,  1, -1,  1 },
                new double[] {  1,  1, -1, -1,  1,  1, -1,  1 },
                new double[] {  1,  1, -1,  1,  1,  1, -1,  1 },
                new double[] { -1, -1,  1, -1, -1, -1,  1,  1 },
                new double[] {  1, -1, -1,  1,  1, -1,  1, -1 },
                new double[] {  1,  1, -1, -1, -1, -1, -1, -1 },
                new double[] {  1,  1, -1, -1,  1,  1,  1, -1 },
                new double[] { -1, -1, -1, -1,  1,  1, -1, -1 },
                new double[] {  1, -1, -1,  1, -1, -1,  1, -1 }
            };

            double[][] bb = new double[20][];

            for (int i = 0; i < 20; i++)
            {
                bb[i] = new double[8];
                for (int j = 0; j < 8; j++)
                {
                    bb[i][j] = aa[i][j] < 0 ? 0 : 1;
                }
            }
            LearningSequence<ISupervisedLearningVector> klockibb = new LearningSequence<ISupervisedLearningVector>();

            for (int i = 0; i < aa.Length; i++)
            {
                klockibb.Add(new SupervisedLearningVector(bb[i], (i>9?0:1)));
                klocki.Add(new SupervisedLearningVector(aa[i], (i>9?-1:1)));
            }

            NeuralNetwork klockineuron = new NeuralNetwork();
            klockineuron.Build(8, null, 1, Neuron.UnipolarActivationFunction, 0.1);
            //PerceptronLearningMethod klockilm = new PerceptronLearningMethod();
            AdalineLMSLearningMethod klockilm = new AdalineLMSLearningMethod();
            klockilm.Epsilon = 1.97;
            klockilm.Alpha = 0.01;
            klockilm.EpochLimit = 1000;
            for (int z = 0; z < 200; z++)
            {

                klockilm.Learn(klockineuron, klockibb);
                if (!klockilm.Failed) Console.WriteLine("Nauczyil sie!");
            }
            Console.WriteLine("Klocki sie nauczyly");
            /*
            klockineuron.SetInput(new double[8] { -1, -1, 1, -1, 1, -1, -1, 1 });
            klockineuron.Compute();
            Console.WriteLine(klockineuron[0] > 0 ? "lubi " : "nie lubi");
            klockineuron.SetInput(new double[8] { 1, -1, 1, -1, -1, 1, -1, 1 });
            klockineuron.Compute();
            Console.WriteLine(klockineuron[0] > 0 ? "lubi " : "nie lubi");
            klockineuron.SetInput(new double[8] { 1, 1, -1, 1, 1, 1, 1, 1 });
            klockineuron.Compute();
            Console.WriteLine(klockineuron[0] > 0 ? "lubi " : "nie lubi");
             
            Console.WriteLine(klockilm.LearningStory.Count + " epok, fail?" + klockilm.Failed);
            klockineuron.SetInput(new double[8] { 0, 0, 1, 0, 1, 0, 0, 1 });
            klockineuron.Compute();
            Console.WriteLine(klockineuron[0] > 0 ? "lubi " : "nie lubi");
            klockineuron.SetInput(new double[8] { 1, 0, 1, 0, 0, 1, 0, 1 });
            klockineuron.Compute();
            Console.WriteLine(klockineuron[0] > 0 ? "lubi " : "nie lubi");
            klockineuron.SetInput(new double[8] { 1, 1, 0, 1, 1, 1, 1, 1 });
            klockineuron.Compute();
            Console.WriteLine(klockineuron[0] > 0 ? "lubi " : "nie lubi");*/
                
        }

        static double testLearn(ISupervisedLearningMethod lm, LearningSequence<ISupervisedLearningVector> seq, ActivationFunction af, int no, double weight)
        {
            NeuralNetwork net;
            
            double a = 0;
            for (int i = 0; i < no; i++)
            {
                net = new NeuralNetwork();
                net.Build(2, null, 1, af, weight);

                lm.Learn(net, seq);
                a += lm.LearningStory.Count;
            }
            return a / no;
        }

        [STAThread]
        static void Main(string[] args)
        {

            //BigTest();
            //Console.ReadKey();
            //return;

            Form1 f = new Form1();
            f.ShowDialog();
            NeuralNetwork nn = new NeuralNetwork();
            nn.Build(2, null, 1, Neuron.BipolarActivationFunction, 0.7);

            LearningSequence<ISupervisedLearningVector> seq = new LearningSequence<ISupervisedLearningVector>();
            seq.Add(new SupervisedLearningVector(new double[2] { -1, -1 }, -1));
            seq.Add(new SupervisedLearningVector(new double[2] { -1, 1 }, -1));
            seq.Add(new SupervisedLearningVector(new double[2] { 1, -1 }, -1));
            seq.Add(new SupervisedLearningVector(new double[2] { 1, 1 }, 1));

            LearningSequence<ISupervisedLearningVector> seq2 = new LearningSequence<ISupervisedLearningVector>();
            seq2.Add(new SupervisedLearningVector(new double[2] { 0, 0 }, 0));
            seq2.Add(new SupervisedLearningVector(new double[2] { 0, 1 }, 0));
            seq2.Add(new SupervisedLearningVector(new double[2] { 1, 0 }, 0));
            seq2.Add(new SupervisedLearningVector(new double[2] { 1, 1 }, 1));

            PerceptronLearningMethod plm = new PerceptronLearningMethod();

            AdalineLMSLearningMethod lms = new AdalineLMSLearningMethod();
            lms.Alpha = 0.02;

            plm.Alpha = 0.2;
            lms.Learn(nn, (ILearningSequence<ISupervisedLearningVector>)seq);

            nn.SetInput(new double[2] { 0.98, 0.99 });
            nn.Compute();
            Console.WriteLine(nn[0]);
            Console.ReadKey();
        }
    }
}
