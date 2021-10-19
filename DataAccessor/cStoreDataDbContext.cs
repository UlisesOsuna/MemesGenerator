using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessor {
	public class cStoreDataDbContext: DbContext {
		public cStoreDataDbContext(DbContextOptions pOptions)
			: base(pOptions) { 
		}

		public List<T> SetTable<T>() where T : class {
			int lNumItems = this.Set<T>().Count();

			if(lNumItems >= 0)
				return this.Set<T>().ToList();

			return null;
		}
     }
}
