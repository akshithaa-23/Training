using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_1
{
    public class Vehicle
    {
        private string _registrationNo { get; set; }
        private string _name { get; set; }
        private string _type { get; set; }
        private double _weight { get; set; }

        private Ticket _ticket;

        public Ticket MyProperty
        {
            get { return _ticket; }
            set { _ticket = value; }
        }


        // Constructor to initialize Vehicle details
        public Vehicle(string registrationNo, string name, string type, double weight, Ticket _ticket)
        {
            this._registrationNo = registrationNo;
            this._name = name;
            this._type = type;
            this._weight = weight;
            this._ticket = _ticket;

        }

        public Vehicle() { }

        // Returns vehicle details as a string when object is printed
        public override string ToString()
        {
            return ($"Registration No:  {_registrationNo} \nName:  {_name} \nType:  {_type}\nWeight: {_weight} \nTicket No:  {_ticket.TicketNo}");

        }


        // Compares this vehicle with another vehicle object based on registartion number and name
        public override bool Equals(object? obj)
        {
            //if (obj == null || !(obj is Vehicle))
            //{
            //    return false;
            //}
            Vehicle v = obj as Vehicle;

            return this._registrationNo.Equals(v._registrationNo) && this._name.Equals(v._name);
        }

    }
}
