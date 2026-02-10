using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_6
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

      

        

        public Vehicle(string _registrationNo, string _name, string _type, double _weight)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
            

        }

        public Vehicle()
        {
        }

       


        public static Vehicle CreateVehicle(string detail)
        {
            // Step 1: Split the string by commaD
            string[] data = detail.Split(',');

            // Step 2: Extract values
            string registrationNo = data[0];
            string ownerName = data[1];
            string type = data[2];
            double weight = Convert.ToDouble(data[3]);
           

           
            // Step 3: Create vehicle object
            Vehicle vehicle = new Vehicle(
       registrationNo,
       ownerName,
       type,
       weight
     );

            // Step 4: Return vehicle object
            return vehicle;
        }
        public override string ToString()
        {
            return string.Format(
                _registrationNo,
                _name,
                _type,
                _weight);
        }

        public static SortedDictionary<string, int> TypeWiseCount(List<Vehicle> vehicleList)
        {
            SortedDictionary<string, int> result = new SortedDictionary<string, int>();

            foreach (Vehicle v in vehicleList)
            {
                if (result.ContainsKey(v.Type))
                {
                    result[v.Type]++;   // increase count
                }
                else
                {
                    result[v.Type] = 1; // first occurrence
                }
            }

            return result;
        }



    }
}
