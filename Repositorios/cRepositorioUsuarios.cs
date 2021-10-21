using DataAccessor;
using Entidades;
using Repositorios.Interfaces;

namespace Repositorios {
	public class cRepositorioUsuarios: cRepositorioBase<tUsuarios>
		, IRepositorioUsuarios {

		private cStoreDataDbContext iContext;

		public cRepositorioUsuarios(cStoreDataDbContext pContext)
			: base(pContext) {

			iContext = pContext;
		}
	}
}
