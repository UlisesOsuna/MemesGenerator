using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominios.Interfaces;
using Entidades;
using Managers.Interfaces;

namespace Managers {
	public class cManagerCategorias: IManagerCategorias {
		private IDominioCategorias iDominio;

		public cManagerCategorias(IDominioCategorias pDominio) {
			iDominio = pDominio;
		}

		public async Task<IList<tCategorias>> ObtenerCategorias(bool pEstanActivos) {
			var lReturn = await iDominio.ObtenerCategorias();
			return lReturn.Where(x => x.EstaActivo == pEstanActivos).ToList();
		}

		public async Task<tCategorias> ObtenerCategoriaPorID(int pIDCategoria) {
			return await iDominio.ObtenerCategoriaPorID(pIDCategoria);
		}

		public async Task<tCategorias> GuardarCategoria(
			int pIDCategoria
			, string pCategoria
			, bool pEstaActivo) {

			return await iDominio.GuardarCategoria(
				pIDCategoria
				, pCategoria
				, pEstaActivo
			);
		}

		public async Task EliminarCategoria(int pIDCategoria) {
			await iDominio.EliminarCategoria(pIDCategoria);
		}
	}
}
