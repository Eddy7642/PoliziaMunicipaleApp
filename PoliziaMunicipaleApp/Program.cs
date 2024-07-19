using PoliziaMunicipaleApp.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Registrazione dei servizi
builder.Services.AddScoped<AnagraficaService>();
builder.Services.AddScoped<TipoViolazioneService>();
builder.Services.AddScoped<VerbaleService>();

var app = builder.Build();

// Configura la pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
