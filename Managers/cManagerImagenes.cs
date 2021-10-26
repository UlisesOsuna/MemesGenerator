using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominios.Interfaces;
using Entidades;
using Managers.Interfaces;
using Modelos;

namespace Managers {
	public class cManagerImagenes: IManagerImagenes {
		private IDominioImagenes iDominio;

		public cManagerImagenes(IDominioImagenes pDominio) {
			iDominio = pDominio;
		}

		public IList<ImagenesModelo> ObtenerImagenes(bool pEstanActivos) {
			var lReturn = iDominio.ObtenerImagenes();
			return lReturn.Where(x => x.EstaActivo == pEstanActivos).ToList();
		}

		public async Task<tImagenes> ObtenerImagenPorID(int pIDImagen) {
			return await iDominio.ObtenerImagenPorID(pIDImagen);
		}

		public async Task GuardarImagenes(IList<tImagenes> pImagenes) {
			await iDominio.GuardarImagenes(pImagenes);
		}

		public async Task EliminarImagenes(IList<int> pIDImagenes) {
			await iDominio.EliminarImagenes(pIDImagenes);
		}
	}
}
