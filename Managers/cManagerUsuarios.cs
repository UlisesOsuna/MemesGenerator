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

		public async Task<tUsuarios> GetUsuario(
			string pUsuario
			, string pContrasenia) {

			return await iDominio.GetUsuario(pUsuario, pContrasenia);
		}
	}
}
