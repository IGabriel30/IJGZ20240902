var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseHttpsRedirection();

//crear una lista para almacenar objetos de tipo Categorias(categorias)
var categorias = new List<Categoria>() {
    new Categoria { Id = 1, Name = "Ropa" },
    new Categoria { Id = 2, Name = "Bebidas" },
    new Categoria { Id = 3, Name = "Alimentos" }
};

//configurar ruta get para obtener todos las categorias
app.MapGet("/categorias", () =>
{

    return Results.Ok(categorias);
});




app.Run();

internal class Categoria
{
    public int Id { get; set; }
    public string Name { get; set; }
}
