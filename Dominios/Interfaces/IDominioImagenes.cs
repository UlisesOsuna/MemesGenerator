﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades;
using Modelos;

namespace Dominios.Interfaces {
	public interface IDominioImagenes {
		IEnumerable<ImagenesModelo> ObtenerImagenes();
		Task<tImagenes> ObtenerImagenPorID(int pIDImagen);
		Task GuardarImagenes(IList<tImagenes> pImagenes);
		Task EliminarImagenes(IList<int> pIDImagenes);
	}
}