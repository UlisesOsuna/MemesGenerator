using System.ComponentModel.DataAnnotations;

namespace Entidades {
	public class tImagenes {
		[Key]
		public int IDImagen {
			get;
			set;
		}

		[Required]
		[StringLength(50)]
		public string Hash {
			get;
			set;
		}

		[Required]
		[StringLength(100)]
		public string Descripcion {
			get;
			set;
		}

		[Required]
		public string Base64 {
			get;
			set;
		}

		[Required]
		public int IDCategoria {
			get;
			set;
		}

		public bool EstaActivo {
			get;
			set;
		}
	}
}
