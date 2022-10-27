// Program.cs
using Microsoft.AspNetCore.ResponseCompression;



using Microsoft.AspNetCore.Authentication.JwtBearer; // NOTE: THIS LINE OF CODE IS NEWLY ADDED
using Microsoft.IdentityModel.Tokens; // NOTE: THIS LINE OF CODE IS NEWLY ADDED
using BlazorJTWAuth.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddTransient<IUserDatabase, UserDatabase>();  // NOTE: LOCAL AUTHENTICATION ADDED HERE; AddTransient() IS OK TO USE BECAUSE STATE IS SAVED TO THE DRIVE

// NOTE: the following block of code is newly added
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidAudience = "domain.com",
        ValidateIssuer = true,
        ValidIssuer = "domain.com",
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("THIS IS THE SECRET KEY")) // NOTE: THIS SHOULD BE A SECRET KEY NOT TO BE SHARED; A GUID IS RECOMMENDED
    };
});
// NOTE: end block


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();


app.UseAuthentication(); // NOTE: line is newly added


app.UseRouting();


app.UseAuthorization(); // NOTE: line is newly addded, notice placement after UseRouting()


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();