using System.Threading.Tasks;
using Dominios.Interfaces;
using Entidades;
using Repositorios.Interfaces;

namespace Dominios {
	public class cDominioUsuarios: IDominioUsuarios {
		private IRepositorioUsuarios iRepositorio;

		public cDominioUsuarios(IRepositorioUsuarios pRepositorio) {
			iRepositorio = pRepositorio;
		}

		public async Task<tUsuarios> LoginUsuario(
			string pUsuario
			, string pContrasenia) {

			tUsuarios lUsuario = null;

			if(!string.IsNullOrEmpty(pUsuario)) {
				lUsuario = await iRepositorio.FindAsync(x =>
					x.Usuario == pUsuario
					&& x.Contrasenia == pContrasenia
					&& x.EstaActivo
				);
			}

			return lUsuario;
		}

		public async Task<tUsuarios> GuardarUsuario(
			int pIDUsuario
			, string pUsuario
			, string pContrasenia
			, bool pEstaActivo) {

			tUsuarios lUsuario = null;

			if(!string.IsNullOrEmpty(pUsuario) && pContrasenia.Length > 0) {
				lUsuario = new tUsuarios() {
					Usuario = pUsuario
					, Contrasenia = pContrasenia
					, EstaActivo = pEstaActivo
				};

				if(pIDUsuario > 0)
					lUsuario = await ActualizarUsuario(pIDUsuario, lUsuario);
				else
					lUsuario = await InsertarUsuario(lUsuario);
			}

			return lUsuario;
		}

		public async Task EliminarUsuario(int pIDUsuario){
			await iRepositorio.DeleteAsync<int>(pIDUsuario, true);
		}

		private async Task<tUsuarios> InsertarUsuario(tUsuarios pUsuario) {
			return await iRepositorio.InsertAsync(pUsuario, true);
		}

		private async Task<tUsuarios> ActualizarUsuario(
			int pIDUsuario
			, tUsuarios pUsuario) {

			pUsuario.IDUsuario = pIDUsuario;
			return await iRepositorio.UpdateAsync<int>(pUsuario, pIDUsuario, true);
		}
	}
}

