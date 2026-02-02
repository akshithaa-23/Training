namespace SalaryLib
{
    public class Class1
    {
        public static double CalcSal(double basicSalary)
        {
            if (basicSalary <= 0)
            {
                throw new Exception("Invalid Salary");
            }

            double hra = 0.20 * basicSalary;
            double da = 0.10 * basicSalary;
            double pf = 0;

            if (basicSalary >= 15000)
                pf = 0.12 * basicSalary;

            return basicSalary + hra + da - pf;
        }
    }
}