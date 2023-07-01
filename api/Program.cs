using api.Contexts;
using api.Mutations;
using api.Queries;
using Keycloak.AuthServices.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var AllowOrigins = "_allowOrigins";


builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQLite
var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(connectionString));

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .RegisterDbContext<DataContext>(DbContextKind.Pooled)
    .AddMutationType<Mutation>()
    .AddQueryType<Query>()
    .AddTypeExtension<NoteQuery>()
    .AddTypeExtension<NoteMutation>();
    

// Keycloak
builder.Services.AddKeycloakAuthentication(builder.Configuration, options =>
{
    options.RequireHttpsMetadata = false;
});

// CORS Policy
builder.Services.AddCors(p => p.AddPolicy(AllowOrigins, builder =>
{
    builder.WithOrigins("http://localhost:3000", "https://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials();
}));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGraphQL();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors(AllowOrigins);

app.Run();
