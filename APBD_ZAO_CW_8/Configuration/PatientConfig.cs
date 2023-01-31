using APBD_ZAO_CW_8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace APBD_ZAO_CW_8.Configuration
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient).HasName("IdPatient_PK");
            builder.Property(e => e.IdPatient).UseIdentityColumn();

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.BirthDate).IsRequired();

            var patients = new List<Patient>();

            patients.Add(new Patient
            {
                IdPatient = 1,
                FirstName = "Oskar",
                LastName = "Deweloperski",
                BirthDate = new DateTime(1988, 5, 1)
            }); ;

            patients.Add(new Patient
            {
                IdPatient = 2,
                FirstName = "Krystian",
                LastName = "Testerski",
                BirthDate = new DateTime(1996, 9, 14)
            });

            patients.Add(new Patient
            {
                IdPatient = 3,
                FirstName = "Agata",
                LastName = "Analityczna",
                BirthDate = new DateTime(1977, 4, 1)
            });



            builder.HasData(patients);
        }
    }
}
