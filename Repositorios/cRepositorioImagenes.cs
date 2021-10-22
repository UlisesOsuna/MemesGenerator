using DataAccessor;
using Entidades;
using Repositorios.Interfaces;

namespace Repositorios {
	public class cRepositorioImagenes: cRepositorioBase<tImagenes>
		, IRepositorioImagenes {

		private cStoreDataDbContext iContext;

		public cRepositorioImagenes(cStoreDataDbContext pContext)
			: base(pContext) {

			iContext = pContext;
		}
	}
}
