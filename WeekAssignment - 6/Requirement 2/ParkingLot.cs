using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2
{
    public class ParkingLot
    {
    

        private List<Vehicle> _vehicleList;
        public List<Vehicle> VehicleList
        {
            get { return _vehicleList; }
            set { _vehicleList = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Default constructor
        private ParkingLot()
        {
            _vehicleList = new List<Vehicle>();   // empty list
        }

        // Parameterized constructor (correct order)
        public ParkingLot(string _name)
        {
            Name = _name;
            VehicleList = new List<Vehicle>();
        }
        // Adds a vehicle to the parking lot list
        public void AddVehcile (Vehicle vehicle)
        {
            _vehicleList.Add(vehicle);
        }
        // Removes a vehicle based on registration number
        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            foreach (Vehicle v in _vehicleList)
            {
                if (v.RegistrationNo.Equals(registrationNo))
                {
                    _vehicleList.Remove(v);
                    return true;
                }
            }

            return false;
           
        }
        // Displays all vehicles in the parking lot
        public void DisplayVehicles()
        {
            if (_vehicleList.Count == 0)
            {
                Console.WriteLine("No vehicles to show");
            }
            else
            {
                Console.WriteLine("Vehicles in " + _name);
                Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                    "Registration No", "Name", "Type", "Weight", "Ticket No");
                foreach (Vehicle v in _vehicleList)
                {
                    

                    Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                        v.RegistrationNo, v.Name, v.Type, v.Weight, v.Tickett.TicketNo);
                }
            }
        }
    }
}
