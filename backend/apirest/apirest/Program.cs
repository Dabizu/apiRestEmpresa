using apirest.context;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificationOrigins = "Permisos";

var builder = WebApplication.CreateBuilder(args);

//Agregada
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificationOrigins,
                        policy =>
                        {

                            policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"))
);

var app = builder.Build();


//con esto se crea la basede datos
/*
using(var scope = app.Services.CreateScope())
{
    var context=scope.ServiceProvider.GetRequiredService<BaseContext>();
    context.Database.Migrate();
}
*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//Agregada
app.UseCors(MyAllowSpecificationOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
