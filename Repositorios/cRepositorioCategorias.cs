using DataAccessor;
using Entidades;
using Repositorios.Interfaces;

namespace Repositorios {
	public class cRepositorioCategorias: cRepositorioBase<tCategorias>
		, IRepositorioCategorias {

		private cStoreDataDbContext iContext;

		public cRepositorioCategorias(cStoreDataDbContext pContext)
			: base(pContext) {

			iContext = pContext;
		}
	}
}
