using System.Threading.Tasks;
using Repositorios.Entidades;

namespace Dominios.Interfaces {
	public interface IDominioUsuarios {
		Task<tUsuarios> LoginUsuario(
			string pUsuario
			, string pContrasenia
		);

		Task<tUsuarios> GuardarUsuario(
			int pIDUsuario
			, string pUsuario
			, string pContrasenia
			, bool pEstaActivo
		);
	}
}
