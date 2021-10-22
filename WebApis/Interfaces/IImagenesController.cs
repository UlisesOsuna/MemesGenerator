using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApis.Solicitudes;

namespace WebApis.Interfaces {
	public interface IImagenesController {
		Task<IActionResult> ObtenerImagenes(ImagenesSolicitud pValue);
		Task<IActionResult> ObtenerImagenPorID(ImagenesSolicitud pValue);
		Task<IActionResult> GuardarImagen(ImagenesSolicitud pValue);
		Task<IActionResult> EliminarImagen(ImagenesSolicitud pValue);
	}
}
