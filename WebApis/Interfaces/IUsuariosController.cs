using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApis.Solicitudes;

namespace WebApis.Interfaces {
	public interface IUsuariosController {
		Task<IActionResult> LoginUsuario(UsuariosSolicitud pValue);
		Task<IActionResult> GuardarUsuario(UsuariosSolicitud pValue);
		Task<IActionResult> EliminarUsuario(UsuariosSolicitud pValue);
	}
}