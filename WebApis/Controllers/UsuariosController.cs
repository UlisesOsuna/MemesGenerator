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
		public async Task<IActionResult> GetUsuario(SolicitudUsuarios pValue) {
			try {
				return (IActionResult) await iManager.GetUsuario(
					pValue.Usuario
					, pValue.Contrasenia
				);
			}
			catch(Exception pEx) {
				return (IActionResult) pEx;
			}
		}
	}
}
