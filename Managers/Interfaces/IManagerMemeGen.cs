using Modelos;

namespace Managers.Interfaces {
	public interface IManagerMemeGen {
		MemeModelo GenerarMeme(
			string pBase64
			, string pTextoOnTop
			, string pTextoOnBottom
		);
	}
}
