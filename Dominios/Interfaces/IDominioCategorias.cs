using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades;

namespace Dominios.Interfaces {
	public interface IDominioCategorias {
		Task<IEnumerable<tCategorias>> ObtenerCategorias();
		Task<tCategorias> ObtenerCategoriaPorID(int pIDCategoria);
		Task<tCategorias> GuardarCategoria(
			int pIDCategoria
			, string pCategoria
			, bool pEstaActivo
		);
		Task EliminarCategoria(int pIDCategoria);
	}
}
