using APBD_ZAO_CW_8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace APBD_ZAO_CW_8.Configuration
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
            builder.Property(e => e.IdDoctor).UseIdentityColumn();

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();

            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();
            builder.HasIndex(e => e.Email).IsUnique();

            var doctors = new List<Doctor>();

            doctors.Add(new Doctor
            {
                IdDoctor = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jan.kowalski@gmail.com"
            });

            doctors.Add(new Doctor
            {
                IdDoctor = 2,
                FirstName = "Adam",
                LastName = "Nowak",
                Email = "a.nowak@wp.pl"
            });

            doctors.Add(new Doctor
            {
                IdDoctor = 3,
                FirstName = "Anna",
                LastName = "Kwiatkowska",
                Email = "akwiatkowska@gmail.com"
            });

            builder.HasData(doctors);
        }
    }
}
