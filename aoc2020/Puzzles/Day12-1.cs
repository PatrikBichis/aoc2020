using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
   public class Day12_1 : PuzzelBase, IPuzzel
   {

       public Day12_1(InputType input) : base(input, 12, 1)
       {
           
       }

       public IPuzzel Run()
       {
            var east = 0;
            var north = 0;
            var south = 0;
            var west = 0;
            var direction = 0; //0:east, 1:south, 2:west, 3:north

            //           /\ 
            //          north 3
            // <- west 2        east 0 ->
            //          south 1
            //           \/

            foreach (var line in Input)
            {
                var cmd = line.Substring(0, 1);
                var value = int.Parse(line.Substring(1, line.Length-1));

                direction = Turn(cmd, value, direction);

                if (direction == 0 && cmd == "F")
                {
                    Forward(ref east, ref west, value);
                }
                else if(direction == 1 && cmd == "F")
                {
                    Forward(ref south, ref north, value);
                }
                else if (direction == 2 && cmd == "F")
                {
                    Forward(ref west, ref east, value);
                }
                else if (direction == 3 && cmd == "F")
                {
                    Forward(ref north, ref south, value);
                }
                else if (cmd == "E")
                {
                    east += value;
                }
                else if (cmd == "S")
                {
                    north -= value;
                }
                else if (cmd == "W")
                {
                    east -= value;
                }
                else if (cmd == "N")
                {
                    north += value;
                }
            }

            Answer = ((east + west) + (north + south)).ToString();

           return this;
       }

        private void Forward(ref int fwd, ref int bwd, int value)
        {
            if (value - bwd > 0)
            {
                fwd = value - bwd;
                bwd = 0;
            }
            else bwd -= value;
        }

        private int Turn(string cmd, int value, int direction)
        {
            if (cmd == "R" || cmd == "L")
            {
                if (cmd == "R" && value == 90)
                    return direction += 1;
                if (cmd == "R" && value == 180)
                    return direction += 2;
                if (cmd == "R" && value == 270)
                    return direction += 3;
                if (cmd == "L" && value == 90)
                    return direction -= 1;
                if (cmd == "L" && value == 180)
                    return direction -= 2;
                if (cmd == "L" && value == 270)
                    return direction -= 3;
            }

            return direction;
        }
   }
} 