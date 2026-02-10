using static Requirement_5.Vehicle;

namespace Requirement_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List to store vehicles
            List<Vehicle> vlist = new List<Vehicle>();

            Console.WriteLine("Requirement -5");
            int option=0;
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
                Console.WriteLine("1.Sort by Weight");
                Console.WriteLine("2.Sort by Parked Time");
                Console.WriteLine("3.Exit");
                Console.WriteLine("Enter Choice : ");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        // Sort vehicles by Weight (IComparable)
                        vlist.Sort();

                        Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                                    "Registration No", "Name", "Type", "Weight", "Ticket No");

                        foreach (Vehicle vv in vlist)
                        {
                            vv.Display();
                        }
                        break;

                    case 2:
                        // Sort vehicles by Parked Time (IComparer)
                        vlist.Sort(new parkedTimeComparer());

                        Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                                   "Registration No", "Name", "Type", "Weight", "Ticket No");

                        foreach (Vehicle vv in vlist)
                        {
                            vv.Display();
                        }
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (option != 3);
        }
    }
}
