using InsuranceLibrary.Models;
using InsuranceLibrary.Services;
using System.Diagnostics;
namespace InsuranceConsoleApp
{
    internal class Program
    {
        static PolicyService service = new PolicyService();


        static void Main(string[] args)
        {

            Console.WriteLine("Menu Driven Program");
            Console.WriteLine("1.Add Policy");
            Console.WriteLine("2.View All Policies");
            Console.WriteLine("3.Search Policy by ID");
            Console.WriteLine("4.Update Policy");
            Console.WriteLine("5.Delete Policy");
            Console.WriteLine("0.Exit");
            int choice;
            do
            {
                Console.Write("Enter Choice");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            AddPolicy();
                            break;
                        }
                    case 2:
                        {
                            ViewPolicies();
                            break;
                        }
                    case 3:
                        {
                            SearchPolicyById(); ;
                            break;
                        }
                    case 4:
                        {
                            updatePolicy();
                            break;
                        }
                    case 5:
                        {
                            DeletePolicy();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }while(choice != 0);

            static void AddPolicy()
            {
                Console.Write("Enter Policy Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Policy Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Duration (years): ");
                int duration = int.Parse(Console.ReadLine());

                service.AddPolicy(new InsurancePolicy
                {
                    PolicyId = id,
                    PolicyHolderName = name,
                    PremiumAmount = amount,
                    PolicyTerm = duration
                });

                Console.WriteLine("Policy added successfully!");
            }

            static void ViewPolicies()
            {
                Console.WriteLine("All Insurance Policies:");
                foreach (var policy in service.GetAllPolicies())
                {
                    Console.WriteLine(policy);
                }

            }
            static void SearchPolicyById()
            {
                Console.Write("Enter Policy Id to search: ");
                int searchId = int.Parse(Console.ReadLine());
                var p = service.GetPolicyById(searchId);
                Console.WriteLine(p != null ? p.ToString() : "Not Found");

            }
            static void updatePolicy()
            {

                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("New Premium: ");
                decimal premium = decimal.Parse(Console.ReadLine());

                Console.Write("New Term: ");
                int term = int.Parse(Console.ReadLine());

                InsurancePolicy updatedPolicy = new InsurancePolicy
                {
                    PremiumAmount = premium,
                    PolicyTerm = term
                };

                Console.WriteLine(service.UpdatePolicy(id, updatedPolicy)
                    ? "Updated"
                    : "Not Found");
            }
            static void DeletePolicy()
            {
                Console.Write("Enter Policy Id to delete: ");
                int deleteId = int.Parse(Console.ReadLine());

                Console.WriteLine(service.DeletePolicy(deleteId) ? "Policy deleted successfully!" : "Policy not found.");
            }
        }
    }
}