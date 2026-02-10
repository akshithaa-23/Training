using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_4
{
    public class VehicleBO
    {
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList,string type)
        {
            // Finds vehicles based on vehicle type (case insensitive)
            List<Vehicle> filteredVehicles = new List<Vehicle>();
            foreach (Vehicle v in vehicleList)
            {
                if (v.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    filteredVehicles.Add(v);
                }
            }
            return filteredVehicles;
        }
        // Finds vehicles based on parked time
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            List<Vehicle> filteredVehicles = new List<Vehicle>();

            foreach (Vehicle v in vehicleList)
            {
                if (v.Tickett != null && v.Tickett.ParkedTime == parkedTime)
                {
                    filteredVehicles.Add(v);
                }
            }

            return filteredVehicles;
        }
    }
}
