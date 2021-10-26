using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApis.Solicitudes;

namespace WebApis.Interfaces {
	public interface IImagenesController {
		IActionResult ObtenerImagenes(ImagenesSolicitud pValue);
		Task<IActionResult> ObtenerImagenPorID(ImagenesSolicitud pValue);
		Task<IActionResult> GuardarImagenes(ImagenesSolicitud pValue);
		Task<IActionResult> EliminarImagenes(ImagenesSolicitud pValue);
	}
}
