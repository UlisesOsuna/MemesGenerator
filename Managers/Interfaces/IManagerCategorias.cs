using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades;

namespace Managers.Interfaces {
	public interface IManagerCategorias {
		Task<IList<tCategorias>> ObtenerCategorias(bool pEstanActivos);
		Task<tCategorias> ObtenerCategoriaPorID(int pIDCategoria);
		Task<tCategorias> GuardarCategoria(
			int pIDCategoria
			, string pCategoria
			, bool pEstaActivo
		);
		Task EliminarCategoria(int pIDCategoria);
	}
}
