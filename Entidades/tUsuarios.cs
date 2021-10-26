using System.ComponentModel.DataAnnotations;

namespace Entidades {
	public class tUsuarios {
		[Key]
		public int IDUsuario {
			get;
			set;
		}

		[Required]
		[StringLength(100)]
		public string Usuario {
			get;
			set;
		}

		[Required]
		[StringLength(100)]
		public string Contrasenia {
			get;
			set;
		}

		public bool EstaActivo {
			get;
			set;
		}
	}
}
