
using Managers;
using Microsoft.Extensions.DependencyInjection;

public class Program {
	public static void Main(string[] args) {
		var services = new ServiceCollection();
		services.AddDominioServices();
	}
}

