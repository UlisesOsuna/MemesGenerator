using System.Threading.Tasks;
using Repositorios.Entidades;

namespace Managers.Interfaces {
	public interface IManagerUsuarios {
		Task<tUsuarios> LoginUsuario(string pUsuario, string pContrasenia);
	}
}
