using Microsoft.OpenApi.Models;
public class SwaggerConfig
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ClientCommande API",
                    Description = "",
                    //TermsOfService = "None",
                    Contact = new OpenApiContact()
                    {
                        Name = "Geoffroy DAUMERM",
                        Email = "geoffroy.daumer@outlook.com",
                        //Url = new"www.dotnetdetail.net"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "ClientCommande API",
                        // Url = "www.dotnetdetail.net"
                    },
                });
            });
        }
    }