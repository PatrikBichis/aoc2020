using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
   public class Day15_1 : PuzzelBase, IPuzzel
   {

       public Day15_1(InputType input) : base(input, 15, 1)
       {
            //var spoken = new Double[];
            var times = 30000000;
            var spoken = new Dictionary<double, int>();

            foreach (var line in Input)
            {
                var parts = line.Trim().Split(',');
                var count = 0;
                var current = (double)0;
                //var spoken = GetInitSpokenNumber(line, times);
                foreach(var p in parts)
                {
                    spoken.Add(double.Parse(p), count);
                    current = double.Parse(p);
                    count++;
                }

                
                while(count < times + 1)
                {

                    //var item = spoken.
                    //NextTurn(ref spoken);
                    //var item = FindPreviouslyValue(spoken, count);
                    //if (spoken.Count(x => x.Value == last.Value) > 1)
                    //{
                    //spoken.Last(x => x.Value == last.Value && x.Id != last.Id);

                    if (spoken.ContainsKey(current) && spoken[current] != count-1)
                    {
                        var a = count + 1;
                        var b = spoken[current] + 1;
                        var sum = a - b;
                        //spoken[count + 1] = sum;// new Spoken { Value = sum });
                        current = sum;
                        if (spoken.ContainsKey(sum))
                            spoken[sum] = count + 1;
                        else
                            spoken.Add(sum, count + 1);
                    }
                    else
                    {
                        current = 0;
                        if (spoken.ContainsKey(0))
                            spoken[0] = count + 1;
                        else
                            spoken.Add(0, count + 1);
                    }
                        //spoken[count + 1] = 0;
                    count++;
                    //Console.WriteLine(count);

                    if (count % 100000 == 0)
                        Console.WriteLine(times - count);
                }

                Console.WriteLine("Number of time spoken: " + spoken[times - 1].ToString());
            }
       }

        private void NextTurn(ref List<Double> spoken)
        {
            //var last = spoken.Last();
            //if(last != null)
            //{
            //var item = FindPreviouslyValue(spoken);
            //if (spoken.Count(x => x.Value == last.Value) > 1)
            //{
            //spoken.Last(x => x.Value == last.Value && x.Id != last.Id);
            /*
            if (item != -1)
            {
                var a = spoken.Count - 1;
                var b = item + 1;
                var sum = a - b;
                spoken.Add(sum);// new Spoken { Value = sum });

            }
            else
                spoken.Add(0);//new Spoken { Value = 0 });
            //}
            */
        }

        private int FindPreviouslyValue(double[] spoken, int count)
        {
            //var count = spoken.Count;
            var lastValue = spoken[count];
            for(int i = count-1; i>=0; i--)
            {
                if (spoken[i] == lastValue)
                    return i;
            }
            
            return -1;
        } 

        private Double[] GetInitSpokenNumber(string line, int times)
        {
            var parts = line.Trim().Split(',');
            var spoken = new double[times + 2];
            var count = 0;
            foreach(var p in parts)
            {
                spoken[count] = double.Parse(p);
                count++;
            }

            return spoken;
        }

        public IPuzzel Run()
       {


           return this;
       }

   }

    class Spoken
    {
        public Spoken()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public double Value { get; set; }
    }
} 