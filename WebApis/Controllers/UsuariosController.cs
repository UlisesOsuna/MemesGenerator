using System;
using System.Threading.Tasks;
using Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApis.Interfaces;
using WebApis.Solicitudes;

namespace WebApis.Controllers {
	[ApiController]
	[Route("Api/[controller]")]
	public class UsuariosController: ControllerBase
		, IUsuariosController {

		private IManagerUsuarios iManager;

		public UsuariosController(IManagerUsuarios pManager) {
			iManager = pManager;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("Login")]
		public async Task<IActionResult> LoginUsuario(UsuariosSolicitud pValue) {
			try {

				return Ok(await iManager.LoginUsuario(
					pValue.Usuario
					, pValue.Contrasenia
				));
			}
			catch(Exception pEx) {
				return Problem(
					pEx.StackTrace
					, pEx.InnerException.ToString()
					, StatusCodes.Status500InternalServerError
					, pEx.Message
					, pEx.Source
				);
			}
		}

		[HttpPost]
		[Authorize]
		[Route("Guardar")]
		public async Task<IActionResult> GuardarUsuario(UsuariosSolicitud pValue) {
			try {
				return Ok(await iManager.GuardarUsuario(
					pValue.IDUsuario
					, pValue.Usuario
					, pValue.Contrasenia
					, pValue.EstaActivo
				));
			}
			catch(Exception pEx) {
				return Problem(
					pEx.StackTrace
					, pEx.InnerException.ToString()
					, StatusCodes.Status500InternalServerError
					, pEx.Message
					, pEx.Source
				);
			}
		}

		[HttpPost]
		[Authorize]
		[Route("Eliminar")]
		public async Task<IActionResult> EliminarUsuario(UsuariosSolicitud pValue) {
			try {
				await iManager.EliminarUsuario(pValue.IDUsuario);
				return Ok(true);
			}
			catch(Exception pEx) {
				return Problem(
					pEx.StackTrace
					, pEx.InnerException.ToString()
					, StatusCodes.Status500InternalServerError
					, pEx.Message
					, pEx.Source
				);
			}
		}
	}
}
