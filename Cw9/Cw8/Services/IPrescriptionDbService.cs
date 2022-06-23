using Cw8.Models.DTOs;
using System.Threading.Tasks;

namespace Cw8.Services
{
    public interface IPrescriptionDbService
    {
        Task<PrescriptionDTO> GetPrescription(int id);

    }
}
