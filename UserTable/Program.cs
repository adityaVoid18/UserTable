//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
////using UserTable.Service;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

////builder.Services.AddControllers();
////builder.Services.AddScoped<IUserService, UserService>();

//// Register JWT Authentication
//var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SecretKey"]);
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key)
//    };
//});


//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();




using JwtExample.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;

using System.Text;
 
var builder = WebApplication.CreateBuilder(args);
 
// Load configuration

var jwtKey = builder.Configuration["Jwt:Key"];

var jwtIssuer = builder.Configuration["Jwt:Issuer"];

var jwtAudience = builder.Configuration["Jwt:Audience"];
 
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
 
// Register JwtService

builder.Services.AddSingleton<JwtService>(provider =>

    new JwtService(jwtKey, jwtIssuer, jwtAudience));
 
// Configure JWT authentication

builder.Services.AddAuthentication(x =>

{

    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})

.AddJwtBearer(x =>

{

    x.RequireHttpsMetadata = false;  // Keep it True in production

    x.SaveToken = true;

    x.TokenValidationParameters = new TokenValidationParameters

    {

        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),

        ValidateIssuer = true,

        ValidateAudience = true,

        ValidIssuer = jwtIssuer,

        ValidAudience = jwtAudience

    };

});
 
var app = builder.Build();
 
if (app.Environment.IsDevelopment())

{

    app.UseSwagger();

    app.UseSwaggerUI();

}
 
app.UseHttpsRedirection();

app.UseAuthentication(); // Enable authentication

app.UseAuthorization();  // Enable authorization
 
app.MapControllers();
 
app.Run();
 
 