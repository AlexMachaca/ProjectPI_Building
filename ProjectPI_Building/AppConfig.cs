using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ProjectPI_Building
{
    public static class AppConfig
    {
        private static IConfiguration _configuration;

        static AppConfig()
        {

            try
            {
                // Cargar la configuración desde appsettings.json
                _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error al cargar la configuración: {ex.Message}");
                throw; // Vuelve a lanzar la excepción para que sea visible
            }
        }

        // Propiedad para obtener la cadena de conexión
        public static string ConnectionString => _configuration.GetConnectionString("DefaultConnection");
    }
}
