using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_4
{
    public class Vehicle
    {
        private string _registrationNo;

        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private Ticket _ticket;

        public Ticket Tickett
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        public object Ticket { get; internal set; }
        // Constructor to initialize Vehicle details
        public Vehicle(string _registrationNo, string _name, string _type, double _weight, Ticket _ticket)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
            this._ticket = _ticket;

        }

        public Vehicle() { }
        //Method to create a Vehicle object from a comma-separated string

        public static Vehicle CreateVehicle(string detail)
        {
            // Step 1: Split the string by commaD
            string[] data = detail.Split(',');

            // Step 2: Extract values
            string registrationNo = data[0];
            string ownerName = data[1];
            string type = data[2];
            double weight = Convert.ToDouble(data[3]);
            string ticketNo = data[4];
            DateTime parkedTime = DateTime.ParseExact(data[5], "dd-MM-yyyy HH:mm:ss", null);
            double cost = Convert.ToDouble(data[6]);

            Ticket ticket = new Ticket(ticketNo, parkedTime, cost);
            // Step 3: Create vehicle object
            Vehicle vehicle = new Vehicle(
       registrationNo,
       ownerName,
       type,
       weight,
       ticket
     );

            // Step 4: Return vehicle object
            return vehicle;
        }
        // Returns vehicle details as a string when object is printed
        public override string ToString()
        {
            return string.Format("{0,-15} {1,-10} {2,-12} {3,-7:F1} {4}",
                RegistrationNo,
                Name,
                Type,
                Weight,
                Tickett.TicketNo);
        }
        // Displays vehicle details in formatted table style
        public void Display()
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7:F1} {4}",
                RegistrationNo,
                Name,
                Type,
                Weight,
                Tickett != null ? Tickett.TicketNo : "N/A");
        }
    }
}
