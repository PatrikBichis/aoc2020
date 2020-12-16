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
            var ranges = new List<Ranges>();
            var _class = new Ranges();
            var _row = new Ranges();
            var _seat = new Ranges();
            var tickets = new List<Ticket>();
            var ticketValues = new List<int>();
            var notValidValues = new List<int>();

            ExtractDataFromInput(ref ranges, ref tickets);

            FindNonValidTickets(ref tickets, ranges);

            Answer = tickets.Where(x=>x.IsValid == false).Sum(x=>x.NonValidValues.Sum()).ToString();

            return this;
        }

        private void FindColumnIndex(List<Ranges> ranges, List<Ticket> tickets)
        {
            var values = new List<int>();
        }

        private void FindNonValidTickets(ref List<Ticket> tickets, List<Ranges> ranges)
        {
            // Find all non valid tickets
            foreach (var ticket in tickets)
            {
                foreach (var i in ticket.Values)
                {
                    var index = 0;
                    var ok1 = ranges[0].IsValuesInRange(i);
                    var ok2 = ranges[1].IsValuesInRange(i);
                    var ok3 = ranges[2].IsValuesInRange(i);
                    if (ranges.All(x=>x.IsValuesInRange(i) == false))
                    {
                        ticket.IsValid = false;
                        ticket.NonValidValues.Add(i);
                        ticket.NonValidIndex.Add(index);
                    }
                    index++;
                }
            }
        }

        private void ExtractDataFromInput(ref List<Ranges> ranges, ref List<Ticket> tickets)
        {
            var yourTicketSeactions = false;
            var ticketSection = false;

            foreach (var line in Input)
            {
                if (line != "")
                {
                    if(!line.Contains("your ticket") && !line.Contains("nearby tickets") && !yourTicketSeactions && !ticketSection)
                    {
                        var r = new Ranges();
                        ExtractRules(ref r, line);
                        ranges.Add(r);
                    }

                    if (ticketSection)
                    {
                        var ticket = new Ticket();
                        var parts = line.Split(",");
                        foreach (var p in parts)
                        {
                            ticket.Values.Add(int.Parse(p));
                        }

                        tickets.Add(ticket);
                    }

                    if (yourTicketSeactions && !ticketSection)
                    {
                        var ticket = new Ticket();
                        ticket.IsMyTicket = true;
                        var parts = line.Split(",");
                        foreach (var p in parts)
                        {
                            ticket.Values.Add(int.Parse(p));
                        }

                        tickets.Add(ticket);
                        yourTicketSeactions = false;
                    }

                    if (line.Contains("your ticket"))
                        yourTicketSeactions = true;

                    if (line.Contains("nearby tickets"))
                        ticketSection = true;
                }
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


    class Ticket
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public bool IsMyTicket { get; set; } = false;

        public List<int> Values { get; set; } = new List<int>();

        public List<int> NonValidValues { get; set; } = new List<int>();

        public List<int> NonValidIndex { get; set; } = new List<int>();

        public bool IsValid = true;
    }
} 