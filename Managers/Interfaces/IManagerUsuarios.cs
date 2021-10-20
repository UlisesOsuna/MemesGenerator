using System.Threading.Tasks;
using Repositorios.Entidades;

namespace Managers.Interfaces {
	public interface IManagerUsuarios {
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
