using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProblemSolving.Data.Context;
using ProblemSolving.Data.Repositories;
using ProblemSolving.Domain.Interfaces;
using ProblemSolving.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

//DB CONTEXT 
//Declare connection string
var connectionString = builder.Configuration.GetConnectionString("ProblemSolvingContext") ?? throw new Exception("ProblemSolving connection string not found");

//Add db context for main project
builder.Services.AddDbContext<ProblemSolvingContext>(option =>
    option.UseSqlServer(connectionString, b => b.MigrationsAssembly("ProblemSolving"))
);

//Add db context and config for identity server 4.
builder.Services.AddIdentityServer()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(connectionString, b => b.MigrationsAssembly("ProblemSolving"));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(connectionString, b => b.MigrationsAssembly("ProblemSolving"));
    })
    .AddDeveloperSigningCredential()
    .AddInMemoryApiScopes(new List<ApiScope>
    {
        new ApiScope("PostApi")
    })
    .AddInMemoryClients(new List<Client>
    {
        new Client
        {
            ClientId = "ClientName",
            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            // secret for authentication
            ClientSecrets =
            {
                new Secret("secretkey".Sha256())
            },
            // scopes that client has access to
            AllowedScopes = { "PostApi" }
        }
    });
// Add JWT token validation
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5000";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Start identity Server
app.UseIdentityServer();

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.UseEndpoints(endpoints =>
    endpoints.MapControllers()
);

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
