using Cw8.Models.DTOs;
using System.Threading.Tasks;

namespace Cw8.Services
{
    public interface IDoctorDbService
    {
        Task<DoctorDTO> GetDoctor(int id);
        Task AddDoctor(DoctorDTO doctor);
         Task UpdateDoctor(int id, DoctorDTO doctor);
         Task DeleteDoctor(int id);
    }
}
