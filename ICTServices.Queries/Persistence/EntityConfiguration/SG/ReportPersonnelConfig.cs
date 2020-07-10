using ICTServices.Queries.Core.Domain.SG;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTServices.Queries.Persistence.EntityConfiguration.SG
{
    public class ReportPersonnelConfig : EntityTypeConfiguration<Report>
    {
        public ReportPersonnelConfig()
        {
           
           
            HasMany(u => u.SGPersonnels)
                .WithMany(p => p.SGReports)
                .Map(m =>
                {

                    m.ToTable("ReportPersonnels", "SG");
                    m.MapLeftKey("ReportID");
                    m.MapRightKey("PersonnelID");
                });
        }
    }
}
