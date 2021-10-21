using Entidades;
using Microsoft.EntityFrameworkCore;

namespace DataAccessor {
	public partial class cStoreDataDbContext {
		public DbSet<tUsuarios> Usuarios {
			get; 
			set;
		}

		protected override void OnModelCreating(ModelBuilder pBuilder) {
			base.OnModelCreating(pBuilder);

			pBuilder.Entity<tUsuarios>().ToTable("tUsuarios");
		}
	}
}
