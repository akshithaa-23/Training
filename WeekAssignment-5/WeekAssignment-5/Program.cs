using System;
using SalaryLib;

namespace WeekAssignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Exercise 1 - Dhoni Runs Pattern");
            Console.WriteLine("2. Exercise 2 - Circle Relationship");
            Console.WriteLine("3. Exercise 3 - Net Salary Calculation");
            Console.WriteLine("4. Exercise 4 - Electricity Bill");
            Console.WriteLine("5. Exercise 5 - Boxing Weight Category");
            Console.WriteLine("0.Exit");
            Console.Write("Enter your choice: ");

            int c = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (c)
            {
                case 1:
                    Exercise1();
                    break;

                case 2:
                    Exercise2();
                    break;

                case 3:
                    Exercise3();
                    break;

                case 4:
                    Exercise4();
                    break;

                case 5:
                    Exercise5();
                    break;

                case 0:
                    Console.WriteLine("Thank you!");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        // Exercise 1 
        static void Exercise1()
        {

            Console.Write("Enter number of matches (N): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Runs scored: ");
            for (int i = 1; i <= n; i++)
            {
                int runs = i * (i * i - 1);
                Console.Write(runs + " ");
            }
            Console.WriteLine();
        }

        // Exercise 2 
        static void Exercise2()
        {
          
            Console.WriteLine("Enter Circle A (ra, xa, ya):");
            double ra = double.Parse(Console.ReadLine());
            double xa = double.Parse(Console.ReadLine());
            double ya = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Circle B (rb, xb, yb):");
            double rb = double.Parse(Console.ReadLine());
            double xb = double.Parse(Console.ReadLine());
            double yb = double.Parse(Console.ReadLine());

            double distance = Math.Sqrt(
                Math.Pow(xa - xb, 2) + Math.Pow(ya - yb, 2)
            );

            if (distance + rb < ra)
                Console.WriteLine("B is in A");
            else if (distance + ra < rb)
                Console.WriteLine("A is in B");
            else if (distance < ra + rb && distance > Math.Abs(ra - rb))
                Console.WriteLine("A and B intersect");
            else
                Console.WriteLine("A and B do not intersect");
        }

        //Exercise 3
        static void Exercise3()
        {

            try
            {
                Console.Write("Enter Basic Salary: ");
                double basicSalary = double.Parse(Console.ReadLine());

                double netSal = Class1.CalcSal(basicSalary);
                Console.WriteLine("Net Salary: " + netSal);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Exercise 4 
        static void Exercise4()
        {
            Console.WriteLine("Exercise 4: Electricity Bill");

            Console.Write("Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.Write("Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Email ID: ");
            string email = Console.ReadLine();

            Console.Write("Type of Connection (Industrial/Business/Domestic/Agricultural): ");
            string connectionType = Console.ReadLine();

            Console.Write("Previous Reading: ");
            int previousReading = int.Parse(Console.ReadLine());

            Console.Write("Current Reading: ");
            int currentReading = int.Parse(Console.ReadLine());

            if (currentReading < previousReading)
            {
                Console.WriteLine("Invalid meter readings");
                return;
            }

            int unitsConsumed = currentReading - previousReading;
            double energyCharge = CalculateEnergy(unitsConsumed);
            double meterRent = GetRent(connectionType);
            double totalAmount = energyCharge + meterRent;

            Console.WriteLine();
            Console.WriteLine("\n=========== ELECTRICITY BILL ===========");
            Console.WriteLine($"Customer ID     : {customerId}");
            Console.WriteLine($"Customer Name   : {customerName}");
            Console.WriteLine($"Address         : {address}");
            Console.WriteLine($"Phone Number    : {phone}");
            Console.WriteLine($"Email ID        : {email}");
            Console.WriteLine($"Connection Type : {connectionType}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Previous Reading : {previousReading}");
            Console.WriteLine($"Current Reading  : {currentReading}");
            Console.WriteLine($"Units Consumed   : {unitsConsumed}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Energy Charges   : ₹ {energyCharge:F2}");
            Console.WriteLine($"Meter Rent       : ₹ {meterRent:F2}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"TOTAL BILL       : ₹ {totalAmount:F2}");
            Console.WriteLine("========================================");

        }

        static double CalculateEnergy(int units)
        {
            double amount;

            if (units <= 100)
                amount = units * 1.5;
            else if (units <= 250)
                amount = (100 * 1.5) + ((units - 100) * 2.5);
            else if (units <= 550)
                amount = (100 * 1.5) + (150 * 2.5) + ((units - 250) * 4.5);
            else
                amount = (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + ((units - 550) * 7.5);

            return amount;
        }

        static double GetRent(string type)
        {
            if (type.Equals("Industrial", StringComparison.OrdinalIgnoreCase))
                return 2500;
            else if (type.Equals("Business", StringComparison.OrdinalIgnoreCase))
                return 1500;
            else if (type.Equals("Domestic", StringComparison.OrdinalIgnoreCase))
                return 1000;
            else if (type.Equals("Agricultural", StringComparison.OrdinalIgnoreCase))
                return 0;
            else
                return 0;
        }
        // Exercise 5 
        static void Exercise5()
        {
            Console.WriteLine("Exercise 5: Boxing Weight Category");

            Console.Write("Enter boxer's weight (kg): ");
            int weight = int.Parse(Console.ReadLine());

            if (weight < 0 || weight > 120)
            {
                Console.WriteLine("Invalid Input");
            }
            else if (weight <= 48)
            {
                Console.WriteLine("Light fly");
            }
            else if (weight <= 51)
            {
                Console.WriteLine("Fly");
            }
            else if (weight <= 54)
            {
                Console.WriteLine("Bantam");
            }
            else if (weight <= 57)
            {
                Console.WriteLine("Feather");
            }
            else if (weight <= 60)
            {
                Console.WriteLine("Light");
            }
            else if (weight <= 64)
            {
                Console.WriteLine("Light welter");
            }
            else if (weight <= 69)
            {
                Console.WriteLine("Welter");
            }
            else if (weight <= 75)
            {
                Console.WriteLine("Light middle");
            }
            else if (weight <= 81)
            {
                Console.WriteLine("Middle");
            }
            else if (weight <= 91)
            {
                Console.WriteLine("Light heavy");
            }
            else
            {
                Console.WriteLine("Heavy");
            }
        }

    }

}
