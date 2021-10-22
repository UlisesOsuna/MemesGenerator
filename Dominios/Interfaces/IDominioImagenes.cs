using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades;

namespace Dominios.Interfaces {
	public interface IDominioImagenes {
		Task<IEnumerable<tImagenes>> ObtenerImagenes();
		Task<tImagenes> ObtenerImagenPorID(int pIDImagen);
		Task<tImagenes> GuardarImagen(
			int pIDImagen
			, string pHash
			, string pDescripcion
			, string pBase64
			, int pIDCategoria
			, bool pEstaActivo
		);
		Task EliminarImagen(int IDImagen);
	}
}
