using System;

namespace Requirement_1
{
    
    public class Ticket
    {
        
        private string _ticketNo;

       
        public string TicketNo
        {
            get { return _ticketNo; }
            set { _ticketNo = value; }
        }

        private DateTime _parkedTime { get; set; }

      
        private double _cost { get; set; }

        // Constructor to initialize ticket details
        public Ticket(string ticketNo, DateTime parkedTime, double cost)
        {
            _ticketNo = ticketNo;
            _parkedTime = parkedTime;
            _cost = cost;
        }
    }
}

