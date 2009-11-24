using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PerceptronIAdaline
{
    using Model.Interfaces;
    using Model.Implementation;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NeuralNetwork net;
        double alpha;
        double maximumAbsoluteWeight;
        bool isBipolar = true;
        bool isAdaline = false;
        ISupervisedLearningMethod learningMethod;

        ILearningSequence<ISupervisedLearningVector> learningSequence;
        DataTable learningSequenceDT;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofn = new OpenFileDialog();
            ofn.Filter = "Plik ciągu uczącego (*.ls)|*.ls";
            ofn.Title = "Wskaż plik ze zbiorem uczącym";
                if (ofn.ShowDialog() == DialogResult.Cancel)
                    return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            learningSequence = new LearningSequence<ISupervisedLearningVector>();
            learningSequenceDT = new DataTable();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = learningSequenceDT;
        }

        private void UpdateLearningSequenceDT()
        {
            dataGridView1.AutoGenerateColumns = true;
            learningSequenceDT.Rows.Clear();
            learningSequenceDT.Columns.Clear();
            int len;

            if (learningSequence.Length > 0 && (len = learningSequence[0].Data.Length) > 0)
            {

                for (int i = 0; i < len; i++)
                {
                    learningSequenceDT.Columns.Add("x" + (i+1));
                }

                learningSequenceDT.Columns.Add("d(X)");

                object[] o = new object[len + 1];
                for (int i = 0; i < learningSequence.Length; i++)
                {
                    for (int j = 0; j < len; j++)
                    {
                        o[j] = learningSequence[i].Data[j];
                    }
                    o[len] = learningSequence[i].CorrectOutput;
                    learningSequenceDT.Rows.Add(o);
                }

                
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    learningSequence = new LearningSequence<ISupervisedLearningVector>();
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { -1, -1 }, -1));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 1, -1 }, -1));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { -1, 1 }, -1));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 1, 1 }, 1));
                    UpdateLearningSequenceDT();
                    break;
                case 1:
                    learningSequence = new LearningSequence<ISupervisedLearningVector>();
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { -1, -1 }, -1));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 1, -1 }, 1));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { -1, 1 }, 1));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 1, 1 }, 1));
                    UpdateLearningSequenceDT();
                    break;
                case 2:
                    learningSequence = new LearningSequence<ISupervisedLearningVector>();
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 0, 0 }, 0));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 1, 0 }, 0));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 0, 1 }, 0));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 1, 1 }, 1));
                    UpdateLearningSequenceDT();
                    break;
                case 3:
                    learningSequence = new LearningSequence<ISupervisedLearningVector>();
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 0, 0 }, 0));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 1, 0 }, 1));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 0, 1 }, 1));
                    learningSequence.Add(new SupervisedLearningVector(new double[2] { 1, 1 }, 1));
                    UpdateLearningSequenceDT();
                    break;
            }
        }
        void licz()
        {
 
            if (isAdaline)
                learningMethod = new Model.Learning.Supervised.AdalineLMSLearningMethod();
            else
                learningMethod = new Model.Learning.Supervised.Bipolar.PerceptronLearningMethod();
            learningMethod.Alpha = alpha;

            learningMethod.Learn(net, learningSequence);
            ble d = pop;
            this.Invoke( d);

            //pop();


        }

        delegate void ble();

        void pop()
        {
            numericUpDown1.Maximum = learningMethod.LearningStory.Count - 1;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Select(0, 1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            log("Uczenie neuronu");
            renewNetwork();
            //System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(licz));
            //th.Start();
            licz();
            log("Nauczono neuron, epok: " + learningMethod.LearningStory.Count);
            log("Koniec uczenia neuronu");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                isAdaline = false;
                renewNetwork();
            }
        }

        private void log(string line)
        {
            listBox2.Items.Add(line);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                alpha = double.Parse(textBox1.Text);
                toolStripStatusLabel1.Text = "Nowy wsp. uczenia: " + alpha;
            }
            catch (Exception ex)
            {
                
                toolStripStatusLabel1.Text = "Niepoprawny współczynnik Alfa (" + ex.Message + ")";
            }
            log(toolStripStatusLabel1.Text);
        }

        private void renewNetwork()
        {
            net = new NeuralNetwork();
            if (learningSequence != null && learningSequence.Length > 0)
            {
                if (isBipolar)
                    net.Build(learningSequence[0].Data.Length, null, 1, Neuron.BipolarActivationFunction, maximumAbsoluteWeight);
                else
                    net.Build(learningSequence[0].Data.Length, null, 1, Neuron.UnipolarActivationFunction, maximumAbsoluteWeight);
                log("Wybudowano nowa sieć.");
                log("Maks. waga: " + maximumAbsoluteWeight);
                log(isBipolar ? "Bipolarna" : "Unipolarna");
            }
            else
            {
                log("Niepoprawny zbior uczacy do budowy sieci.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                maximumAbsoluteWeight = double.Parse(textBox2.Text);
                toolStripStatusLabel1.Text = "Nowa maks. waga: " + maximumAbsoluteWeight;
                
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Niepoprawnad wartość maksimum bezwzględnego wag (" + ex.Message + ")";
                
            }
            log(toolStripStatusLabel1.Text);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                isAdaline = true;
                renewNetwork();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                isBipolar = false;
            }
            else
                isBipolar = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (learningMethod != null && learningMethod.LearningStory != null
                && learningMethod.LearningStory.Count > 0)
            {
                Model.Learning.NeuronState state = learningMethod.LearningStory[(int)numericUpDown1.Value];
                if (state.Inputs != null && state.Weights != null && state.Weights.Length == state.Inputs.Length)
                {
                    textBox3.Text = "Output: " + state.Output;
                    for (int i = 0; i < state.Weights.Length; i++)
                    {
                        textBox3.Text += "\r\n---\r\n|W: " + state.Weights[i] + "\r\n|I: " + state.Inputs[i];
                    }
                }
            }
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (net != null)
                    net.SetInput(new double[2] { double.Parse(textBox4.Text), double.Parse(textBox5.Text) });
                net.Compute();
                textBox6.Text = net[0].ToString();
            }
            catch (Exception ex)
            {
            }
        }
     }
}
