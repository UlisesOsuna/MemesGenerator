using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades;
using Modelos;

namespace Managers.Interfaces {
	public interface IManagerImagenes {
		IList<ImagenesModelo> ObtenerImagenesOfFolder(string pPathFolder);
		Task<IList<tImagenes>> ObtenerImagenes(bool pEstanActivos);
		Task<tImagenes> ObtenerImagenPorID(int pIDImagen);
		Task<tImagenes> GuardarImagen(
			int pIDImagen
			, string pHash
			, string pDescripcion
			, string pBase64
			, int pIDCategoria
			, bool pEstaActivo
		);
		Task EliminarImagen(int pIDImagen);
	}
}
