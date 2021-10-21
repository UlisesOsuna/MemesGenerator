using Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Managers {
	public static class cServiceCollectionExtension {
          public static IServiceCollection AddDominioServices(this IServiceCollection source) {
               source.AddTransient<IManagerUsuarios, cManagerUsuarios>();
               return source;
          }
     }
}
