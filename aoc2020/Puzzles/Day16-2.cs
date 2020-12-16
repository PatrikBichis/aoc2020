using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
   public class Day16_2 : PuzzelBase, IPuzzel
   {

       public Day16_2(InputType input) : base(input, 16, 2)
       {
           
       }

        public IPuzzel Run()
        {
            var _class = new Ranges();
            var _row = new Ranges();
            var _seat = new Ranges();
            var ticketValues = new List<int>();
            var notValidValues = new List<int>();

            ExtractDataFromInput(ref _class, ref _row, ref _seat, ref ticketValues);

            foreach (var i in ticketValues)
            {
                if (!_class.IsValuesInRange(i) && !_row.IsValuesInRange(i) && !_seat.IsValuesInRange(i))
                {
                    notValidValues.Add(i);
                }
            }

            Answer = notValidValues.Sum().ToString();

            return this;
        }

        private void ExtractDataFromInput(ref Ranges _class, ref Ranges _row, ref Ranges _seat, ref List<int> values)
        {
            var yourTicketSeactions = false;
            var ticketSection = false;

            foreach (var line in Input)
            {
                if (ticketSection)
                {
                    var parts = line.Split(",");
                    foreach (var p in parts)
                    {
                        values.Add(int.Parse(p));
                    }
                }

                if (line.Contains("class") && !ticketSection && !yourTicketSeactions)
                    ExtractRules(ref _class, line);
                if (line.Contains("row") && !ticketSection && !yourTicketSeactions)
                    ExtractRules(ref _row, line);
                if (line.Contains("seat") && !ticketSection && !yourTicketSeactions)
                    ExtractRules(ref _seat, line);

                if (line.Contains("nearby tickets"))
                    ticketSection = true;
            }
        }

        private void ExtractRules(ref Ranges list, string line)
        {
            var parts = line.Split(':');
            var ranges = parts[1].Split("or");

            list.Name = parts[0];

            foreach (var r in ranges)
            {
                var limits = r.Trim().Split("-");
                var range = new Range(parts[0]);
                range.Lower = int.Parse(limits[0]);
                range.Upper = int.Parse(limits[1]);
                list.Values.Add(range);
            }
        }
    }
} 