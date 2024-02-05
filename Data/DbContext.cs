using Microsoft.EntityFrameworkCore;

namespace NikeshBiraggari_002299909_01.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

    }
}
