namespace Requirement_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List to store vehicles
            List<Vehicle> vlist = new List<Vehicle>();

            Console.WriteLine("Requirement -6");

            int n = 0;

            try
            {
                // Read number of vehicles
                Console.WriteLine("Enter no . of Vehicles : ");
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number entered.");
                return;
            }

            // Input vehicle details
            for (int i = 0; i < n; i++)
            {
                try
                {
                    Vehicle vv = new Vehicle();

                    Console.WriteLine("Enter the details of the vehicle in the format RegistrationNo,Name,Type,Weight");
                    string detail = Console.ReadLine();

                    vv = Vehicle.CreateVehicle(detail);

                    vlist.Add(vv);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid vehicle details: " + ex.Message);
                    i--; // retry same input
                }
            }

            // Get type-wise vehicle count
            SortedDictionary<string, int> typeCount = Vehicle.TypeWiseCount(vlist);

            // Display result in table format
            Console.WriteLine("{0,-15} {1}", "Type", "No. of Vehicles");

            foreach (var item in typeCount)
            {
                Console.WriteLine("{0,-15} {1}", item.Key, item.Value);
            }
        }
    }
}
