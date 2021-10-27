using System;
using Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApis.Interfaces;
using WebApis.Solicitudes;

namespace WebApis.Controllers {
	[ApiController]
	[Route("Api/[controller]")]
	public class MemeGenController: ControllerBase
		, IMemeGenController {

		private IManagerMemeGen iManager;

		public MemeGenController(IManagerMemeGen pManager) {
			iManager = pManager;
		}

		[HttpPost]
		[Authorize]
		[Route("GetMeme")]
		public IActionResult GenerarMeme(MemeGenSolicitud pValue) {
			try {
				return Ok(iManager.GenerarMeme(
					pValue.Base64
					, pValue.TextoOnTop
					, pValue.TextoOnBottom
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
	}
}
