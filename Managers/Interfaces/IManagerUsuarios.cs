using System.Threading.Tasks;
using Entidades;
using Modelos;

namespace Managers.Interfaces {
	public interface IManagerUsuarios {
		Task<UsuariosModelo> LoginUsuario(
			string pUsuario
			, string pContrasenia
		);

		Task<tUsuarios> GuardarUsuario(
			int pIDUsuario
			, string pUsuario
			, string pContrasenia
			, bool pEstaActivo
		);

		Task EliminarUsuario(int pIDUsuario);
	}
}
