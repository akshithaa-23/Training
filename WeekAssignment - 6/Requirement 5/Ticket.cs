using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_5
{
    public class Ticket
    {
		private string _ticketNo;

		public string TicketNo
		{
			get { return _ticketNo; }
			set { _ticketNo = value; }
		}
		private DateTime _parkedTime;

		public DateTime ParkedTime
		{
			get { return _parkedTime; }
			set { _parkedTime = value; }
		}

		private double _cost;

		public double Cost
		{
			get { return _cost; }
			set { _cost = value; }
		}

		public Ticket() { }
        // Constructor to initialize ticket details
        public Ticket(string _ticketNo, DateTime _parkedTime, double _cost)
		{
			this._ticketNo = _ticketNo;
			this._parkedTime = _parkedTime;
			this._cost = _cost;
        }
    }
}
