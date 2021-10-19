using System.Threading.Tasks;
using Repositorios.Entidades;

namespace Dominios.Interfaces {
	public interface IDominioUsuarios {
		Task<tUsuarios> GetUsuario(string pUsuario, string pContrasenia);
	}
}
