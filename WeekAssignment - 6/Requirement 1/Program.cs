namespace Requirement_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parking Lot Requirement 1");

            try
            {
                // ----------- VEHICLE 1 INPUT -----------
                Console.WriteLine("Give Input - Registration no,name,type,weight,ticket no,parked time ,cost");
                Console.WriteLine("Enter Vehicle 1 detail:");

                // Read input and split using comma
                string[] deets = Console.ReadLine().Split(',');

                // Assign values from input
                string registrationNo = deets[0];
                string name = deets[1];
                string type = deets[2];
                double weight = double.Parse(deets[3]);
                string ticketNo = deets[4];

                // Parse date in exact format
                DateTime parkedTime = DateTime.ParseExact(
                    deets[5],
                    "dd-MM-yyyy HH:mm:ss",
                    null
                );


                double cost = double.Parse(deets[6]);

                // Create Ticket object
                Ticket ticket = new Ticket(ticketNo, parkedTime, cost);

                // Create Vehicle object
                Vehicle v1 = new Vehicle(registrationNo, name, type, weight, ticket);


                // ----------- VEHICLE 2 INPUT -----------
                Console.WriteLine("Give Input - Registration no,name,type,weight,ticket no,parked time ,cost");
                Console.WriteLine("Enter Vehicle 2 detail:");

                string[] deets1 = Console.ReadLine().Split(',');

                Ticket ticket1 = new Ticket(
                    deets1[4],
                    DateTime.ParseExact(deets1[5], "dd-MM-yyyy HH:mm:ss", null),
                    double.Parse(deets1[6])
                );

                Vehicle v2 = new Vehicle(
                    deets1[0],
                    deets1[1],
                    deets1[2],
                    double.Parse(deets1[3]),
                    ticket1
                );

                // ----------- DISPLAY DETAILS -----------
                Console.WriteLine(v1);
                Console.WriteLine();
                Console.WriteLine(v2);
                Console.WriteLine();

                // Compare vehicles
                if (v1.Equals(v2))
                {
                    Console.WriteLine("Vehicle 1 is same as Vehicle 2");
                }
                else
                {
                    Console.WriteLine("Vehicle 1 is not same as Vehicle 2");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input format is incorrect. Please check number or date format.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Insufficient input values. Please enter all required fields.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error occurred: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
