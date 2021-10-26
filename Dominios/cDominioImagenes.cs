using System.Collections.Generic;
using System.Threading.Tasks;
using Dominios.Interfaces;
using Entidades;
using Modelos;
using Repositorios.Interfaces;

namespace Dominios {
	public class cDominioImagenes: IDominioImagenes {
		private IRepositorioImagenes iRepositorio;

		public cDominioImagenes(IRepositorioImagenes pRepositorio) {
			iRepositorio = pRepositorio;
		}

		public IEnumerable<ImagenesModelo> ObtenerImagenes() {
			return iRepositorio.ObtenerImagenes();
		}

		public async Task<tImagenes> ObtenerImagenPorID(int pIDImagen) {
			return await iRepositorio.GetByIDAsync(pIDImagen);
		}

		public async Task GuardarImagenes(IList<tImagenes> pImagenes) {
			foreach(tImagenes lItem in pImagenes) {
				bool lFlagHash = !string.IsNullOrEmpty(lItem.Hash);
				bool lFlagBase64 = !string.IsNullOrEmpty(lItem.Base64);
				bool lFlagIDCategoria = (lItem.IDCategoria > 0);

				if(lFlagHash && lFlagBase64 && lFlagIDCategoria) {
					if(lItem.IDImagen > 0)
						await ActualizarImagen(lItem.IDImagen, lItem);
					else
						await InsertarImagen(lItem);
				}
			}

			await iRepositorio.CommitAsync();
		}

		public async Task EliminarImagenes(IList<int> pIDImagenes) {
			for(int i = 0; i < pIDImagenes.Count; i++) {
				await iRepositorio.DeleteAsync<int>(pIDImagenes[i]);
			}

			await iRepositorio.CommitAsync();
		}

		private async Task<tImagenes> InsertarImagen(tImagenes pImagen) {
			return await iRepositorio.InsertAsync(pImagen);
		}

		private async Task<tImagenes> ActualizarImagen(
			int pIDImagen
			, tImagenes pImagen) {

			pImagen.IDImagen = pIDImagen;
			return await iRepositorio.UpdateAsync<int>(pImagen, pIDImagen);
		}
	}
}
