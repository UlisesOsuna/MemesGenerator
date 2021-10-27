using Microsoft.AspNetCore.Mvc;
using WebApis.Solicitudes;

namespace WebApis.Interfaces {
	public interface IMemeGenController {
		IActionResult GenerarMeme(MemeGenSolicitud pValue);
	}
}
