using APBD_ZAO_CW_8.Models;
using APBD_ZAO_CW_8.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_ZAO_CW_8.Repository
{
    public class HospitalDbRepository : IHospitalDbRepository
    {

        private readonly Context _context;

        public HospitalDbRepository(Context context)
        {
            _context = context;
        }
        public async Task<string> AddDoctorAsync(DoctorDto dto)
        {
            try
            {
                await _context.AddAsync(new Doctor
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return "There is a doctor with that email!";
            }

            return "Success!";
        }

        public async Task<string> ChangeDoctorAsync(int id, DoctorDto dto)
        {
            var wantedDoctor = await _context.Doctor.FindAsync(id);

            if (wantedDoctor == null)
                return "Cannot find the doctor!";

            wantedDoctor.LastName = dto.LastName;
            wantedDoctor.FirstName = dto.FirstName;
            wantedDoctor.Email = dto.Email;

            await _context.SaveChangesAsync();

            return "Success!";
        }

        public async Task<string> DeleteDoctorAsync(int id)
        {
            var wantedDoctor = await _context.Doctor.FindAsync(id);

            if (wantedDoctor == null)
                return "Cannot find the doctor!";

            var isHavingPatiets = await _context.Prescription.AnyAsync(e => e.IdDoctor == id);

            if (isHavingPatiets)
                return "Cannot delete the doctor!";

            _context.Remove(wantedDoctor);
            await _context.SaveChangesAsync();

            return "Success!";
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsAsync()
        {
            return await _context.Doctor.Select(e => new DoctorDto
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email
            }).ToListAsync();
        }

        public async Task<PrescriptionDto> GetPrescriptionAsync(int id)
        {
            var wantedPrescription = await _context.Prescription.FindAsync(id);

            if (wantedPrescription == null)
                return null;

            PrescriptionDto prescriptionDto = await _context
                .Prescription
                .Where(e => e.IdPrescription == id)
                .Select(e => new PrescriptionDto
                {
                    PrescriptionDate = e.Date,
                    PrescriptionDueDate = e.DueDate,
                    PatientFirstName = e.IdPatientNav.FirstName,
                    PatientLastName = e.IdPatientNav.LastName,
                    PatientBirthDate = e.IdPatientNav.BirthDate,
                    DoctorFirstName = e.IdDoctorNav.FirstName,
                    DoctorLastName = e.IdDoctorNav.LastName,
                    DoctorEmail = e.IdDoctorNav.Email,
                    Medicaments = e.PrescriptionMedicaments.Select(e => new MedicamentDto
                    {
                        Name = e.IdMedicamentNav.Name,
                        Details = e.Details,
                        Dose = e.Dose
                    })
                }).FirstAsync();

            return prescriptionDto;
        }
    }
}
