using System;
using System.Threading.Tasks;
using Managers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApis.Interfaces;
using WebApis.Solicitudes;

namespace WebApis.Controllers {
	[ApiController]
	[Route("Api/[controller]")]
	public class CategoriasController: ControllerBase
		, ICategoriasController {

		private IManagerCategorias iManager;

		public CategoriasController(IManagerCategorias pManager) {
			iManager = pManager;
		}

		[HttpPost]
		[Route("GetAll")]
		public async Task<IActionResult> ObtenerCategorias(CategoriasSolicitud pValue) {
			try {
				return Ok(await iManager.ObtenerCategorias(pValue.EstaActivo));
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
		[Route("GetByID")]
		public async Task<IActionResult> ObtenerCategoriaPorID(CategoriasSolicitud pValue) {
			try {
				return Ok(await iManager.ObtenerCategoriaPorID(pValue.IDCategoria));
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
		[Route("Guardar")]
		public async Task<IActionResult> GuardarCategoria(CategoriasSolicitud pValue) {
			try {
				return Ok(await iManager.GuardarCategoria(
					pValue.IDCategoria
					, pValue.Categoria
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
		[Route("Eliminar")]
		public async Task<IActionResult> EliminarCategoria(CategoriasSolicitud pValue) {
			try {
				await iManager.EliminarCategoria(pValue.IDCategoria);
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
