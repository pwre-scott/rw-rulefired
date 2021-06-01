using System;
using System.Collections.Generic;
using System.Text;

namespace RiverWarePlugin
{
    class RiverWare
    {
        public string OutputDataFilePath = "C:/SkDevOps/RiverWarePlugin/Elevation.dat";

        public string InputDataFilePath = "C:/SkDevOps/RiverWarePlugin/PluginInput.dat";

        private readonly Random _random = new Random();

        public void WriteInputFile()
        {
            List<string> lines = new List<string>();

            lines.Add("data_date: 2020-12-10 24:00");
            lines.Add(ReadOutputFile());

            using(System.IO.StreamWriter file = 
                new System.IO.StreamWriter(InputDataFilePath))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(line);
                }
            }

            System.Threading.Thread.Sleep(10000);
        }

        public string ReadOutputFile()
        {
            using(System.IO.StreamReader file = new System.IO.StreamReader(OutputDataFilePath))
            {
                List<string> lines = new List<string>();
                string line;
                while((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                lines.RemoveAll(item => item == "NaN");
                lines.RemoveRange(0, 6);

                List<double> nums = new List<double>();
                foreach(string item in lines)
                {
                    nums.Add(Convert.ToDouble(item));
                }

                var sum = 0.0;
                nums.ForEach(x => sum += x);

                double avg = sum / (double)nums.Count;
                return avg.ToString();

            }
        }

    }
}
