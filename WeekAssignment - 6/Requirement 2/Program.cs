using System.Xml.Serialization;

namespace Requirement_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the name of the Parking Lot: ");
            string name = Console.ReadLine();
            int choice;
            ParkingLot lot = new ParkingLot(name);
            do
            {
                Console.WriteLine("1.Add Vehicle \n2.Delete Vehicle \n3.Display Vehicles \n4.Exit ");
                Console.WriteLine("Enter your choice:");

                try
                {
                    // Convert user input to integer
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue; // restart loop
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Give Input - Registration no,name,type,weight,ticket no,parked time ,cost");
                            Console.WriteLine("Enter : ");

                            string input = Console.ReadLine();

                            // Create vehicle using factory method
                            Vehicle v = Vehicle.CreateVehicle(input);

                            lot.AddVehcile(v);
                            Console.WriteLine("Vehicle successfully added");
                            break;

                        case 2:
                            Console.WriteLine("Enter the registration number of the vehicle to be deleted:");
                            string regNo = Console.ReadLine();

                            bool res = lot.RemoveVehicleFromParkingLot(regNo);

                            if (res)
                                Console.WriteLine("Vehicle successfully deleted");
                            else
                                Console.WriteLine("Vehicle not found");

                            break;

                        case 3:
                            // Display all vehicles
                            lot.DisplayVehicles();
                            break;

                        case 4:
                            Console.WriteLine("Exiting");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Handles unexpected errors (like wrong vehicle input format)
                    Console.WriteLine("Error: " + ex.Message);
                }

            } while (true); 
        }

    }
}

