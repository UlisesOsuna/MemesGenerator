using System.Collections.Generic;
using Entidades;

namespace WebApis.Solicitudes {
	public class ImagenesSolicitud {
		public int IDImagen {
			get;
			set;
		}

		public bool EstaActivo {
			get;
			set;
		}

		public List<tImagenes> Imagenes {
			get;
			set;
		}

		public List<int> IDsImagenes {
			get;
			set;
		}
	}
}
