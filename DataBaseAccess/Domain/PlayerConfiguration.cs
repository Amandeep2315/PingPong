using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace DataBaseAccess.Domain
{
    public class PlayerConfiguration :EntityTypeConfiguration<Player>
    {
       public PlayerConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Age).IsOptional();
        }
    }
}
