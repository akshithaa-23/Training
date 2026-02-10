using System.Globalization;
using System.Text.RegularExpressions;

namespace Requirement_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Registration No ");
            string registrationNo = Console.ReadLine();
            // Convert input to uppercase
            registrationNo = registrationNo.ToUpper();
            if (ValidateRegistrationNo(registrationNo))
            {
                Console.WriteLine("Valid Registration No");
            }
            else
            {
                Console.WriteLine("Invalid Registration No");
            }
            // Validates registration number using regex pattern
            static bool ValidateRegistrationNo(string registrationNo)
            {
                string pattern = @"^[A-Z]{2} [0-9]{1,2} [A-Z]{0,2} [0-9]{1,4}$";

                return Regex.IsMatch(registrationNo, pattern);
            }
        }
    }
}
            