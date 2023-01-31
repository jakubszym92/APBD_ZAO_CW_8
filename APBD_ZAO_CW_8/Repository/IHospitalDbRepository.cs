using APBD_ZAO_CW_8.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APBD_ZAO_CW_8.Repository
{
    public interface IHospitalDbRepository
    {
        Task<IEnumerable<DoctorDto>> GetDoctorsAsync();
        Task<string> AddDoctorAsync(DoctorDto dto);
        Task<string> ChangeDoctorAsync(int id, DoctorDto dto);
        Task<string> DeleteDoctorAsync(int id);
        Task<PrescriptionDto> GetPrescriptionAsync(int id);
    }
}
