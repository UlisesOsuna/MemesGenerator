using System;
using System.Threading.Tasks;
using Dominios.Interfaces;
using Repositorios.Entidades;
using Repositorios.Interfaces;

namespace Dominios {
	public class cDominioUsuarios: IDominioUsuarios {
		private IRepositorioUsuarios iRepositorio;

		public cDominioUsuarios(IRepositorioUsuarios pRepositorio) {
			iRepositorio = pRepositorio;
		}

		public async Task<tUsuarios> GetUsuario(
			string pUsuario
			, string pContrasenia) {

			tUsuarios lUsuario = null;

			if(!string.IsNullOrEmpty(pUsuario)) {
				lUsuario = await iRepositorio.FindAsync(x =>
					x.Usuario == pUsuario
					&& x.Contrasenia == pContrasenia
				);
			}

			return lUsuario;
		}
	}
}

