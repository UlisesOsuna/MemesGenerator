using System.Collections.Generic;
using System.Linq;
using DataAccessor;
using Entidades;
using Modelos;
using Repositorios.Interfaces;

namespace Repositorios {
	public class cRepositorioImagenes: cRepositorioBase<tImagenes>
		, IRepositorioImagenes {

		private cStoreDataDbContext iContext;

		public cRepositorioImagenes(cStoreDataDbContext pContext)
			: base(pContext) {

			iContext = pContext;
		}

		public IEnumerable<ImagenesModelo> ObtenerImagenes() {
			List<tImagenes> lTablaImagenes = this.DbSet.ToList();
			List<tCategorias> lTablaCategorias = iContext.Categorias.ToList();

			return (
				from lImg in lTablaImagenes
				join lCat in lTablaCategorias
					on lImg.IDCategoria equals lCat.IDCategoria
				select new ImagenesModelo() {
					IDImagen = lImg.IDImagen
					,Hash = lImg.Hash
					,Descripcion = lImg.Descripcion
					,Base64 = lImg.Base64
					,IDCategoria = lImg.IDCategoria
					,Categoria = lCat.Categoria
					,EstaActivo = lImg.EstaActivo
				}
			);
		}
	}
}
