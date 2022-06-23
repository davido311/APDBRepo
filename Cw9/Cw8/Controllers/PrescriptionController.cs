using Cw8.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cw8.Controllers
{
    [Route("prescriptions")]
    [ApiController]
    [Authorize]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionDbService _prescriptionDbService;

        public PrescriptionController(IPrescriptionDbService prescriptionDbService)
        {
            _prescriptionDbService = prescriptionDbService;
        }

        [HttpGet("{idPrescription}")]
        public async Task<IActionResult> GetPrescription(int idPrescription)
        {
            try
            {
                return Ok(await _prescriptionDbService.GetPrescription(idPrescription));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

     
        

    }
}
