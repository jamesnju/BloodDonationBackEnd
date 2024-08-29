using BloodDonation.Data;
using BloodDonation.Models.Entities;
using BloodDonation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonarController : ControllerBase
    {
        private readonly DonationDbContext dbContext;

        public DonarController(DonationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //get all donars
        [HttpGet("GetAllDonars")]
        public IActionResult GetAllDonars()
        {
            var donars = dbContext.DonationCandidates;
            if(donars == null)
            {
                return NotFound("No Donar Found");
            }
            return Ok(donars);
        }
        //get donar by id
        [HttpGet("GetDonarById/{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {
            try
            {
                var donor = await dbContext.DonationCandidates.FindAsync(id);
                if (donor == null)
                {
                    return NotFound("Donor not found");
                }
                return Ok(donor);
            }
            catch (Exception ex)
            {
                // Log the exception details (ex) as needed
                return StatusCode(500, "Internal server error");
            }
        }



        //create donar
        [HttpPost("CreateDonar")]
        public IActionResult CreateDonar(AddDonarDto addDonar)
        {
            if (addDonar.BloodGroup.Length >= 3)
            {
                return BadRequest("Blood Group must be less than 3 characters");
            }

            //validate for empty fields
            if (string.IsNullOrEmpty(addDonar.FullName) || 
              
                string.IsNullOrEmpty(addDonar.BloodGroup) || 
                string.IsNullOrEmpty(addDonar.PhoneNumber) ||
                string.IsNullOrEmpty(addDonar.Address) ||
                string.IsNullOrEmpty(addDonar.Email))
            {
                return BadRequest("Please fill all the fields");
            }
            var donar = new DonationCandidate
            {
                FullName = addDonar.FullName,
                Age = addDonar.Age,
                BloodGroup = addDonar.BloodGroup,
                PhoneNumber = addDonar.PhoneNumber,
                Address = addDonar.Address,
                Email = addDonar.Email
            };
            dbContext.DonationCandidates.Add(donar);    
            dbContext.SaveChanges();

            return Ok(donar);
            
        }
        // Edit donar details
        [HttpPut("UpdateDonorDetails/{id}")]
        public async Task<IActionResult> UpdateDonarDetails(int id, UpdateDonarDetails updateDonar)
        {
            var donar = await dbContext.DonationCandidates.FindAsync(id);
            if (donar == null)
            {
                return NotFound("Donar not found");
            }
            if(updateDonar.BloodGroup.Length >= 3)
            {
                return BadRequest("Blood Group must be less than 3 characters");
            }
            donar.FullName = updateDonar.FullName;
            donar.Age = updateDonar.Age;
            donar.BloodGroup = updateDonar.BloodGroup;
            donar.PhoneNumber = updateDonar.PhoneNumber;
            donar.Address = updateDonar.Address;
            donar.Email = updateDonar.Email;

            dbContext.DonationCandidates.Update(donar);
            dbContext.SaveChanges();
            return Ok(donar);

        }
        //delete donar
        [HttpDelete("DeleteDonorById/{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            var donar = await dbContext.DonationCandidates.FindAsync(id);
            if (donar == null)
            {
                return NotFound("Donar not found");
            }
            dbContext.DonationCandidates.Remove(donar);
            dbContext.SaveChanges();
            return Ok("Donar deleted successfully");
        }
    }
}
