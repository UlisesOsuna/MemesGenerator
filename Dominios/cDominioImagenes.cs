using System.Collections.Generic;
using System.Threading.Tasks;
using Dominios.Interfaces;
using Entidades;
using Repositorios.Interfaces;

namespace Dominios {
	public class cDominioImagenes: IDominioImagenes {
		private IRepositorioImagenes iRepositorio;

		public cDominioImagenes(IRepositorioImagenes pRepositorio) {
			iRepositorio = pRepositorio;
		}

		public async Task<IEnumerable<tImagenes>> ObtenerImagenes() {
			return await iRepositorio.GetAllAsync();
		}

		public async Task<tImagenes> ObtenerImagenPorID(int pIDImagen) {
			return await iRepositorio.GetByIDAsync(pIDImagen);
		}

		public async Task<tImagenes> GuardarImagen(
			int pIDImagen
			, string pHash
			, string pDescripcion
			, string pBase64
			, int pIDCategoria
			, bool pEstaActivo) {

			tImagenes lImagen = null;
			bool lFlagHash = !string.IsNullOrEmpty(pHash);
			bool lFlagBase64 = !string.IsNullOrEmpty(pBase64);
			bool lFlagIDCategoria = (pIDCategoria > 0);

			if(lFlagHash && lFlagBase64 && lFlagIDCategoria) {
				lImagen = new tImagenes() {
					Hash = pHash
					, Descripcion = pDescripcion
					, Base64 = pBase64
					, IDCategoria = pIDCategoria
					, EstaActivo = pEstaActivo
				};

				if(pIDImagen > 0)
					lImagen = await ActualizarImagen(pIDImagen, lImagen);
				else
					lImagen = await InsertarImagen(lImagen);
			}

			return lImagen;
		}

		public async Task EliminarImagen(int pIDImagen) {
			await iRepositorio.DeleteAsync<int>(pIDImagen, true);
		}

		private async Task<tImagenes> InsertarImagen(tImagenes pImagen) {
			return await iRepositorio.InsertAsync(pImagen, true);
		}

		private async Task<tImagenes> ActualizarImagen(
			int pIDImagen
			, tImagenes pImagen) {

			pImagen.IDImagen = pIDImagen;
			return await iRepositorio.UpdateAsync<int>(pImagen, pIDImagen, true);
		}
	}
}
