namespace WebApplication1.Models
{
    public class Patients
    {
        public int PatientID { get; set; }
        public string? PatientName { get; set; }  //making it nullable to avoid issues with null values
        public int PatientAge { get; set; }
        public double PatientBill { get; set; }
    }
}
