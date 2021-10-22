using System.ComponentModel.DataAnnotations;

namespace Entidades {
	public class tCategorias {
		[Key]
		public int IDCategoria {
			get;
			set;
		}

		[Required]
		[StringLength(200)]
		public string Categoria {
			get;
			set;
		}

		public bool EstaActivo {
			get;
			set;
		}
	}
}
