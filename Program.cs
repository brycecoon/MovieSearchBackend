using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieSearchBackend.Data;
using MovieSearchBackend.Data.Interfaces;
using MovieSearchBackend.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = "https://auth.snowse.duckdns.org/realms/advanced-frontend",
            ValidAudience = "bryce-oAuth2",
        };
        options.Authority = "https://auth.snowse.duckdns.org/realms/advanced-frontend";
    });

builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddHealthChecks();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostgresContext>(options => options.UseNpgsql(builder.Configuration["DB"]));

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IListService, ListService>();
builder.Services.AddScoped<IList_MovieService, List_MovieService>();
string? apikey = builder.Configuration["APIKEY"];
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p =>
p.AllowAnyHeader()
.AllowAnyMethod()
.AllowAnyOrigin());

app.UseHttpsRedirection();
app.MapHealthChecks("/api/healthy");

app.UseAuthorization();


app.MapControllers();

app.Run();
