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
	public class ImagenesController: ControllerBase
		, IImagenesController {

		private IManagerImagenes iManager;

		public ImagenesController(IManagerImagenes pManager) {
			iManager = pManager;
		}

		[HttpPost]
		[Authorize]
		[Route("GetAll")]
		public IActionResult ObtenerImagenes(ImagenesSolicitud pValue) {
			try {
				return Ok(iManager.ObtenerImagenes(pValue.EstaActivo));
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
		[Route("GetByID")]
		public async Task<IActionResult> ObtenerImagenPorID(ImagenesSolicitud pValue) {
			try {
				return Ok(await iManager.ObtenerImagenPorID(pValue.IDImagen));
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
		public async Task<IActionResult> GuardarImagenes(ImagenesSolicitud pValue) {
			try {
				await iManager.GuardarImagenes(pValue.Imagenes);
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

		[HttpPost]
		[Authorize]
		[Route("Eliminar")]
		public async Task<IActionResult> EliminarImagenes(ImagenesSolicitud pValue) {
			try {
				await iManager.EliminarImagenes(pValue.IDsImagenes);
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
