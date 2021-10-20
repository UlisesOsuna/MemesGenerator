using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repositorios.Entidades;
using WebApis.Interfaces;
using WebApis.Solicitudes;

namespace WebApis.Controllers {
	[ApiController]
	[Route("Api/{controller}")]
	public class UsuariosController: ControllerBase
		, IUsuariosController {

		private IManagerUsuarios iManager;

		public UsuariosController(IManagerUsuarios pManager) {
			iManager = pManager;
		}

		[HttpPost]
		public async Task<IActionResult> LoginUsuario(UsuariosSolicitud pValue) {
			try {
				return (IActionResult) await iManager.LoginUsuario(
					pValue.Usuario
					, pValue.Contrasenia
				);
			}
			catch(Exception pEx) {
				return (IActionResult) pEx;
			}
		}

		[HttpPost]
		public async Task<IActionResult> GuardarUsuario(UsuariosSolicitud pValue) {
			try {
				return (IActionResult) await iManager.GuardarUsuario(
					pValue.IDUsuario
					, pValue.Usuario
					, pValue.Contrasenia
					, pValue.EstaActivo
				);
			}
			catch(Exception pEx) {
				return (IActionResult) pEx;
			}
		}
	}
}
