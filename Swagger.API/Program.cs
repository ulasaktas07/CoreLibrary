using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swagger.API.Models;
using Swashbuckle.Swagger;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SwagerDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration["ConnectionStrings"]);
});
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("productV1", new OpenApiInfo
	{
		Title = "Product API",
		Version = "V1",
		Description = "Ürün Ekleme/Silme/Güncelleme iþlemlerini gerçekleþtiren API",
		Contact = new OpenApiContact
		{
			Name = "Ulaþ Aktaþ",
			Email = "ulasaktas882@gmail.com",
			Url = new Uri("https://www.ulasaktas.com")
		}
	});

	// XML yorumlarý için dosya yolu
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	c.IncludeXmlComments(xmlPath);
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}


app.UseSwagger();
app.UseSwaggerUI(options =>
{
	options.SwaggerEndpoint("/swagger/productV1/swagger.json", "Product API");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
