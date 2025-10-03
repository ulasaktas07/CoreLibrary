using ErrorHandling.Filter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
builder.Services.AddMvc(options =>
{
	options.Filters.Add(new CustomHandleExceptionFilterAttribute() { ErrorPage="hata1"});
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseDeveloperExceptionPage();
//app.UseExceptionHandler(context =>
//{
//	context.Run(async page =>
//	{
//		page.Response.StatusCode = 500;
//		page.Response.ContentType = "text/html";
//		await page.Response.WriteAsync($"<htlm><head> <h1> Hata var: {page.Response.StatusCode}</h1></head> </html>");
//	});
//});
//app.UseStatusCodePages("text/plain", "Bir hata var. Durum kodu:{0}");
app.UseStatusCodePages(async context =>
{
	context.HttpContext.Response.ContentType = "text/plain";
	await context.HttpContext.Response.WriteAsync($"Bir hata var durum kodu: {context.HttpContext.Response.StatusCode}");
});
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}")
	.WithStaticAssets();


app.Run();
