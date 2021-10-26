namespace Modelos {
	public class ImagenesModelo {
		public int IDImagen {
			get;
			set;
		}

		public string Hash {
			get;
			set;
		}

		public string Descripcion {
			get;
			set;
		}

		public string Base64 {
			get;
			set;
		}

		public int IDCategoria {
			get;
			set;
		}

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
