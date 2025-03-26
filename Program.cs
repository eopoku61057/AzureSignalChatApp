using Microsoft.Azure.SignalR;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin() // ✅ Allows all origins
            .AllowAnyMethod() // ✅ Allows all HTTP methods (GET, POST, PUT, DELETE, etc.)
            .AllowAnyHeader()); // ✅ Allows all headers
});
builder.Services.AddSignalR()
    .AddAzureSignalR();
//var clientId = "9fa09405-4ebf-48c6-b85d-59ff802a2a36";
//builder.Services.AddSignalR().AddAzureSignalR(option =>
//{
//    option.Endpoints = new ServiceEndpoint[]
//    {
//        new ServiceEndpoint(new Uri("https://azsignalrtest.service.signalr.net"), new ManagedIdentityCredential(clientId)),
//    };
//});
var app = builder.Build();

app.UseDefaultFiles();
app.UseRouting();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.MapHub<ChatSampleHub>("/chat");
app.Run();