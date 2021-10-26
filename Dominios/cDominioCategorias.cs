using System.Collections.Generic;
using System.Threading.Tasks;
using Dominios.Interfaces;
using Entidades;
using Repositorios.Interfaces;

namespace Dominios {
	public class cDominioCategorias: IDominioCategorias {
		private IRepositorioCategorias iRepositorio;

		public cDominioCategorias(IRepositorioCategorias pRepositorio) {
			iRepositorio = pRepositorio;
		}

		public async Task<IEnumerable<tCategorias>> ObtenerCategorias() {
			return await iRepositorio.GetAllAsync();
		}

		public async Task<tCategorias> ObtenerCategoriaPorID(int pIDCategoria) {
			return await iRepositorio.GetByIDAsync(pIDCategoria);
		}

		public async Task<tCategorias> GuardarCategoria(
			int pIDCategoria
			, string pCategoria
			, bool pEstaActivo) {

			tCategorias lCategoria = null;

			if(!string.IsNullOrEmpty(pCategoria)) {
				lCategoria = new tCategorias() {
					Categoria = pCategoria
					, EstaActivo = pEstaActivo
				};

				if(pIDCategoria > 0)
					lCategoria = await ActualizarCategoria(pIDCategoria, lCategoria);
				else
					lCategoria = await InsertarCategoria(lCategoria);
			}

			return lCategoria;
		}

		public async Task EliminarCategoria(int pIDCategoria) {
			await iRepositorio.DeleteAsync<int>(pIDCategoria, true);
		}

		private async Task<tCategorias> InsertarCategoria(tCategorias pCategoria) {
			return await iRepositorio.InsertAsync(pCategoria, true);
		}

		private async Task<tCategorias> ActualizarCategoria(
			int pIDCategoria
			, tCategorias pCategoria) {

			pCategoria.IDCategoria = pIDCategoria;
			return await iRepositorio.UpdateAsync<int>(pCategoria, pIDCategoria, true);
		}
	}
}
