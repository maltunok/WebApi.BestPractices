using Microsoft.AspNetCore.Authorization;
using OwnerPermission.Data;
using OwnerPermission.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
		.AddNegotiate();

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("EditPolicy", policy =>
			policy.Requirements.Add(new SameAuthorRequirement()));
});

builder.Services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationCrudHandler>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
