using Entidades;
using Microsoft.EntityFrameworkCore;

namespace DataAccessor {
	public partial class cStoreDataDbContext {
		public DbSet<tUsuarios> Usuarios {
			get; 
			set;
		}

		public DbSet<tCategorias> Categorias {
			get;
			set;
		}

		public DbSet<tImagenes> Imagenes {
			get;
			set;
		}

		protected override void OnModelCreating(ModelBuilder pBuilder) {
			base.OnModelCreating(pBuilder);

			pBuilder.Entity<tUsuarios>().ToTable("tUsuarios");
			pBuilder.Entity<tCategorias>().ToTable("tCategorias");
			pBuilder.Entity<tImagenes>().ToTable("tImagenes");
		}
	}
}
