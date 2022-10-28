#region namespaces required to setup database services
using Microsoft.EntityFrameworkCore;
using WestwindSystem; // To be able to set extension method AddBackendDependencies in StartupExtensions.cs
#endregion

var builder = WebApplication.CreateBuilder(args);

#region code required to setup database services
var dbConnectionString = builder.Configuration.GetConnectionString("WestwindLocalDb");
// neccessary to connect to BLL classes
builder.Services.AddBackendDependencies(options => options.UseSqlServer(dbConnectionString));

/* Alternative way without extensions
 * Step 1)
 * If the BLL classes were declared as public instead of internal you can do this instead
builder.Services.AddDbContext<WestwindContext>(options =>
{
    // Verify that the NuGet package Microsoft.EntityFrameworkCore.SqlServer has been installed
    options.UseSqlServer(dbConnectionString);
});

Step 2)
// The AddTransient<T>() method adds a transient service of the type T to resolve each dependency on type T
builder.Services.AddTransient<BuildVersionServices>(serviceProvider =>
{
    var context = serviceProvider.GetRequiredService<WestwindContext>();
    return new BuildVersionServices(context);
});
builder.Services.AddTransient<CategoryServices>(serviceProvider =>
{
    var context = serviceProvider.GetRequiredService<WestwindContext>();
    return new CategoryServices(context);
});
*/
#endregion

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
