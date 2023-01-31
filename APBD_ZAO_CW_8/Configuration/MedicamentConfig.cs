using APBD_ZAO_CW_8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace APBD_ZAO_CW_8.Configuration
{
    public class MedicamentConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament).HasName("IdMedicament_PK");
            builder.Property(e => e.IdMedicament).UseIdentityColumn();

            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Type).HasMaxLength(100).IsRequired();

           
            var medicaments = new List<Medicament>();

            medicaments.Add(new Medicament
            {
                IdMedicament = 1,
                Name = "Etorpiryna",
                Description = "Przeciwbólowy lek w tabletkach powlekanych",
                Type = "Przeciwbólowy"
            });

            medicaments.Add(new Medicament
            {
                IdMedicament = 2,
                Name = "Haloperidol",
                Description = "Lek przeciwpsychotyczny w tabletkach lub dożylnie",
                Type = "Przeciwpsychotyczny"
            });

            medicaments.Add(new Medicament
            {
                IdMedicament = 3,
                Name = "Kwas salicylowy ",
                Description = "Niesteroidowy lek przeciwzapalny w tabletkach",
                Type = "Przeciwzapalny"
            });

            builder.HasData(medicaments);
        }
    }
}
