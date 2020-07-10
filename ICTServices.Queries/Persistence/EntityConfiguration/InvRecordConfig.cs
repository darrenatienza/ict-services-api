using API.Queries.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Persistence.EntityConfiguration
{
    public class InvRecordConfig : EntityTypeConfiguration<InvRecord>
    {
        public InvRecordConfig(){
           
        }
        
    }
}
