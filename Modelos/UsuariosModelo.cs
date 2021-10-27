namespace Modelos {
	public class UsuariosModelo {
		public int IDUsuario {
			get;
			set;
		}

		public string Usuario {
			get;
			set;
		}

		public string Contrasenia {
			get;
			set;
		}

		public string Salt {
			get;
			set;
		}

		public string Token {
			get;
			set;
		}

		public bool EstaActivo {
			get;
			set;
		}
	}
}
