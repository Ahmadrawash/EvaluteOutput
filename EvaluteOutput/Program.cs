using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluteOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stream s = File.OpenRead("C:\\Users\\ahmed\\source\\repos\\openai-master\\openai-master\\OpenAI.Playground\\bin\\Debug\\net7.0\\files\\"
                + "sresult (All).txt");
            var fs = new StreamReader(s);
            Stream outputS = File.OpenWrite("C:\\Users\\ahmed\\source\\repos\\openai-master\\openai-master\\OpenAI.Playground\\bin\\Debug\\net7.0\\files\\"
                + "sresult_eval (All).txt");
            Stream outputT = File.OpenWrite("C:\\Users\\ahmed\\source\\repos\\openai-master\\openai-master\\OpenAI.Playground\\bin\\Debug\\net7.0\\files\\"
                + "sresult_evalTrue (All).txt");
            Stream outputF = File.OpenWrite("C:\\Users\\ahmed\\source\\repos\\openai-master\\openai-master\\OpenAI.Playground\\bin\\Debug\\net7.0\\files\\"
                + "sresult_evalFalse (All).txt");
            var outs = new StreamWriter(outputS);
            var outT = new StreamWriter(outputT);
            var outF = new StreamWriter(outputF);
            outs.WriteLine("Invention, Inventor, Date, Found, ChatGPT_Result");
            outs.Flush();
            String line = fs.ReadLine().Trim();
            String q, corrAns, Dtime, output, chatgpt;
            bool evaluation;
            while (!fs.EndOfStream)
            {
                line = fs.ReadLine().Trim();
                q = ""; corrAns = ""; Dtime = ""; output = ""; q = ""; 
                 evaluation = false;
                if (line != null && line.Split(',').Length > 0)
                {
                    q = line.Split(',')[0].Trim();
                    if (line.Split(',').Length >= 2)
                        corrAns = line.Split(',')[1].Trim();
                    if (line.Split(',').Length >= 3)
                        Dtime = line.Split(',')[2].Trim();
                    if (line.Split(',').Length >= 4)
                    {
                        int find = line.IndexOf(',');
                        int sfind = line.IndexOf(',', find + 1);
                        int tfind = line.IndexOf(',', sfind + 1);
                        //int Ffind = line.IndexOf(',', tfind + 1);

                        output = line.Substring(tfind+1);
                    }

                    if (output.ToLower().IndexOf(corrAns.ToLower()) != -1)
                        evaluation = true;

                    if (evaluation)
                    {
                        Console.WriteLine("T");
                        outT.WriteLine((evaluation ? "T" : "F") + "," +
                            q.Substring(q.IndexOf("what is the name of the inventor of ") +
                            "what is the name of the inventor of ".Length) + ","
                            + corrAns + "," + Dtime + "," + output);
                        outT.Flush();
                    }
                    else
                    {
                        Console.WriteLine("F");
                        outF.WriteLine((evaluation ? "T" : "F") + "," +
                            q.Substring(q.IndexOf("what is the name of the inventor of ") +
                            "what is the name of the inventor of ".Length ) + ","
                            + corrAns + "," + Dtime + "," + output);
                        outF.Flush();
                    }
                    outs.WriteLine((evaluation ? "T" : "F") + "," +
                            q.Substring(q.IndexOf("what is the name of the inventor of ") +
                            "what is the name of the inventor of ".Length ) + ","
                            + corrAns + "," + Dtime + "," + output);
                    outs.Flush();
                }
            }

            Console.WriteLine("************** END ***********");
        }
    }
}


          //if (found == false)
          //{
          //    if (!line.Split(',')[0].StartsWith("Titanium"))
          //        continue;
          //    else
          //        found = true;
          //}