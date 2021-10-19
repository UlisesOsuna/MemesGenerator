using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repositorios.Entidades;
using WebApis.Solicitudes;

namespace WebApis.Interfaces {
	public interface IUsuariosController {
		Task<IActionResult> LoginUsuario(LoginSolicitud pValue);
	}
}