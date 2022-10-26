using Data;
using Share.Dto;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Services.EFService;
using Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Data.ValidationUser;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient();


#region FluentValidation
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddTransient<IValidator<UserDto>, UserDtoValidation>();
builder.Services.AddTransient<IValidator<LoginUserDto>, LoginUserDtoValidation>();
#endregion

#region JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
#endregion

#region DbContext
builder.Services.AddDbContext<TaskManageContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
     b => b.MigrationsAssembly(typeof(TaskManageContext).Assembly.FullName));
});
#endregion

#region Contract
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IUserServive, UserService>();
builder.Services.AddScoped<ILog_Activity, Log_ActivityService>(); 
builder.Services.AddScoped<IloginUserService, loginUserService>();
builder.Services.AddScoped<IGenerateJSONWebToken, GenerateJSONWebToken>();
builder.Services.AddScoped<ISecurePasswordHasher, SecurePasswordHasher>();
#endregion

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder
                          //.AllowAnyOrigin()
                          .AllowAnyOrigin()
                            //.WithOrigins("http://localhost:5090" , "http://localhost:7208")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                           
                      });
});
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme
)
.AddCookie();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();








