using System.Threading.Tasks;
using Dominios.Interfaces;
using Managers.Interfaces;
using Repositorios.Entidades;

namespace Managers {
	public class cManagerUsuarios: IManagerUsuarios {
		private IDominioUsuarios iDominio;

		public cManagerUsuarios(IDominioUsuarios pDominio) {
			iDominio = pDominio;
		}

		public async Task<tUsuarios> LoginUsuario(
			string pUsuario
			, string pContrasenia) {

			return await iDominio.LoginUsuario(pUsuario, pContrasenia);
		}

		public async Task<tUsuarios> GuardarUsuario(
			int pIDUsuario
			, string pUsuario
			, string pContrasenia
			, bool pEstaActivo) {

			return await iDominio.GuardarUsuario(
				pIDUsuario
				, pUsuario
				, pContrasenia
				, pEstaActivo
			);
		}
	}
}
