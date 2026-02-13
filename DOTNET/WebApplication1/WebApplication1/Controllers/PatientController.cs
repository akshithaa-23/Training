using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        // Simulating a database with an in-memory list of patients
        private static List<Patients> patients = new List<Patients>
        {
            new Patients { PatientID = 1, PatientName = "John Doe", PatientAge = 30, PatientBill = 1000.00 },
            new Patients { PatientID = 2, PatientName = "Jane Smith", PatientAge = 25, PatientBill = 1500.00 },
            new Patients { PatientID = 3, PatientName = "Bob Johnson", PatientAge = 40, PatientBill = 2000.00 }
        };

        [HttpGet] //mEANING WE ARE GETTING RREQUEST
                  // GET: api/Patient

        //public ActionResult<IEnumerable<Patients>> GetPatients()
        //{
        //    return Ok(patients); // Return the list of patients
        //}


        public IActionResult GetAll()
        {
            return Ok(patients); // Return the list of patients
        }

        [HttpGet("{id}")] // GET: api/Patient/1]

        public IActionResult GetPatientById(int id)
        {
            var patient = patients.FirstOrDefault(p => p.PatientID == id);
            if (patient == null)
            {
                return NotFound("No Ptients Found"); // Return 404 if patient not found
            }
            return Ok(patient); // Return the patient details
        }


        [HttpPost] // POST: api/Patient
        public IActionResult Create(Patients newPatient)
        {
            //if (newPatient == null)
            //{
            //    return BadRequest("Invalid patient data."); // Return 400 if the request body is null
            //}
            // Generate a new PatientID (you can use a more robust method in a real application)
            newPatient.PatientID = patients.Max(p => p.PatientID) + 1;
            patients.Add(newPatient);
            return CreatedAtAction(nameof(GetPatientById), new { id = newPatient.PatientID }, newPatient); // Return 201 with the location of the created resource

        }

        [HttpDelete("{id}")] // DELETE: api/Patient/1
        public IActionResult Delete(int id)
        {
            var patient = patients.FirstOrDefault(p => p.PatientID == id);
            if (patient == null)
            {
                return NotFound("No Ptients Found"); // Return 404 if patient not found
            }
            patients.Remove(patient);
            return NoContent(); // Return 204 No Content to indicate successful deletion
        }

        [HttpPut]
        public IActionResult Update(Patients updatedPatient)
        {
            var existingPatient = patients.FirstOrDefault(p => p.PatientID == updatedPatient.PatientID);
            if (existingPatient == null)
            {
                return NotFound("No Ptients Found"); // Return 404 if patient not found
            }
            existingPatient.PatientName = updatedPatient.PatientName;
            existingPatient.PatientAge = updatedPatient.PatientAge;
            existingPatient.PatientBill = updatedPatient.PatientBill;
            return NoContent(); // Return 204 No Content to indicate successful update
        }
    }
}
