using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades;
using Modelos;

namespace Managers.Interfaces {
	public interface IManagerImagenes {
		IList<ImagenesModelo> ObtenerImagenes(bool pEstanActivos);
		Task<tImagenes> ObtenerImagenPorID(int pIDImagen);
		Task GuardarImagenes(IList<tImagenes> pImagenes);
		Task EliminarImagenes(IList<int> pIDImagenes);
	}
}
