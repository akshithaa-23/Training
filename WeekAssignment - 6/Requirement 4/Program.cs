namespace Requirement_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List to store vehicles
            List<Vehicle> vlist = new List<Vehicle>();

            Console.WriteLine("Requirement -4");
            int choice=0;
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
                    Console.WriteLine("Enter the details of the vehicle in the format RegistrationNo,Name,Type,Weight,Parked Time,cost");
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

            do
            {
                VehicleBO v = new VehicleBO();

                Console.WriteLine("1.Search By Type\n2.Search By ParkedTime");
                Console.WriteLine("Enter your choice");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        // Search by vehicle type
                        Console.WriteLine("Enter the type of vehicle");
                        string type = Console.ReadLine();

                        List<Vehicle> result1 = v.FindVehicle(vlist, type);

                        if (result1.Count == 0)
                        {
                            Console.WriteLine("No such vehicle is present");
                        }
                        else
                        {
                            Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                                "Registration No", "Name", "Type", "Weight", "Ticket No");

                            foreach (Vehicle vv in result1)
                            {
                                vv.Display();
                            }
                        }
                        break;

                    case 2:
                        try
                        {
                            // Search by parked time
                            Console.WriteLine("Enter the  of vehicle");
                            string input = Console.ReadLine();

                            DateTime parkedTime = DateTime.ParseExact(input, "dd-MM-yyyy HH:mm:ss", null);

                            List<Vehicle> result2 = v.FindVehicle(vlist, parkedTime);

                            if (result2.Count == 0)
                            {
                                Console.WriteLine("No such vehicle is present");
                            }
                            else
                            {
                                Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                                    "Registration No", "Name", "Type", "Weight", "Ticket No");

                                foreach (Vehicle vehicle in result2)
                                {
                                    vehicle.Display();
                                }
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (choice != 3);
        }
    }
}
