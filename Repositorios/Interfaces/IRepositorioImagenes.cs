using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessor;
using Entidades;
using Modelos;

namespace Repositorios.Interfaces {
	public interface IRepositorioImagenes: IRepositorioBase<tImagenes> {
		IEnumerable<ImagenesModelo> ObtenerImagenes();
	}
}
