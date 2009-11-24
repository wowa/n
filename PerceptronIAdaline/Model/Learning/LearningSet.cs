using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace PerceptronIAdaline.Model.Learning
{
    class LearningSet
    {
        LearningVector[] vectors;

        public LearningVector this[int n]
        {
            get
            {
                return vectors[n];
            }
            set
            {
                vectors[n] = value;
            }
        }

        public int Size
        {
            get
            {
                return vectors.Length;
            }
        }

        public void Shuffle()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 4 + rand.Next(Size); i-- != 0; )
            {
                int n = rand.Next(Size), m = rand.Next(Size);
                LearningVector temp = vectors[n];
                vectors[n] = vectors[m];
                vectors[m] = temp;
            }
        }

        public bool Load(Stream file)
        {

            try
            {
                TextReader tr = new StreamReader(file);
                string line;
                Regex spaces = new Regex(@"\s+");
                int v, s; // vector, set sizes;

                line = tr.ReadLine();
                string[] fields = spaces.Split(line);
                s = int.Parse(fields[0]);
                v = int.Parse(fields[1]);
                double[][] data = new double[s][];
                Console.WriteLine("S: " + s + " V: " + v);
                for (int j = 0; j < s; j++)
                {
                    if ((line = tr.ReadLine()) == null)
                        return false;
                    data[j] = new double[v];

                    fields = spaces.Split(line);

                    Console.WriteLine("LINE: " + line + " SPLIT: " + fields.Length);
                    Console.Write("FIELDS:");
                    for (int i = 0; i < fields.Length; i++)
                    {
                        Console.Write("|" + fields[i] + "| ");
                    }
                    Console.WriteLine();
                    for (int i = 0; i < v; i++)
                        data[j][i] = double.Parse(fields[i]);
                }

                vectors = new LearningVector[s];

                for (int i = 0; i < s; i++)
                    vectors[i] = new LearningVector(data[i]);

                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('|');
            for (int i = 0; i < vectors[0].Size; i++)
            {
                sb.AppendFormat(" {0,-3} |", (vectors[0].Size-1 == i) ? "y" : "x" + (i+1));
            }
            sb.AppendLine();

            for (int i = 0; i < vectors.Length; i++)
            {
                sb.AppendLine(vectors[i].ToString());
            }
            return sb.ToString();
        }
    }
}
