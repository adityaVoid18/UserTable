
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;

using Microsoft.IdentityModel.Tokens;

using System.Text;
 
public class Startup

{

    public void ConfigureServices(IServiceCollection services)

    {

        // Configure JWT Authentication

        var key = Encoding.ASCII.GetBytes("Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx"); // Use Strong Secret Key
 
        services.AddAuthentication(x =>

        {

            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        })

        .AddJwtBearer(x =>

        {

            x.RequireHttpsMetadata = false; // Production mein true karna

            x.SaveToken = true;

            x.TokenValidationParameters = new TokenValidationParameters

            {

                ValidateIssuerSigningKey = true,

                IssuerSigningKey = new SymmetricSecurityKey(key),

                ValidateIssuer = false,

                ValidateAudience = false

            };

        });
 
        services.AddControllers(); // Add Controller

    }
 
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

    {

        if (env.IsDevelopment())

        {

            app.UseDeveloperExceptionPage();  // Show error page in Development Mode

        }
 
        app.UseRouting();   // Enable Routing
 
        app.UseAuthentication(); // Enable Authentication

        app.UseAuthorization();  // Enable Authorization
 
        app.UseEndpoints(endpoints =>

        {

            endpoints.MapControllers();  // Endpoints Map of controller

        });

    }

}
 

