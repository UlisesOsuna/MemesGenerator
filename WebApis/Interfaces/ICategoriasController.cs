using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApis.Solicitudes;

namespace WebApis.Interfaces {
	public interface ICategoriasController {
		Task<IActionResult> ObtenerCategorias(CategoriasSolicitud pValue);
		Task<IActionResult> ObtenerCategoriaPorID(CategoriasSolicitud pValue);
		Task<IActionResult> GuardarCategoria(CategoriasSolicitud pValue);
		Task<IActionResult> EliminarCategoria(CategoriasSolicitud pValue);
	}
}
