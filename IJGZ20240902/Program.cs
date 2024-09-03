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
var categorias = new List<Categoria>();

//configurar ruta get para obtener todos las categorias
app.MapGet("/categorias", () =>
{

    return categorias;
});

//configurar ruta get para obtener una categoria en especifico por su id
app.MapGet("/categorias/{id}", (int id) =>
{
    //busca una categoria que tenga el id especificado
    var categoria = categorias.FirstOrDefault(c => c.Id == id);
    return categoria;//devuelve la categoria encontrada o null sino la encuentra
});

//configurar una ruta POST para agregar un nuevo cliente  ala lista
app.MapPost("/categorias", (Categoria categoria) =>
{
    categorias.Add(categoria);//agrega nuevo cliente a la lista
    return Results.Ok();//devuelve una respuesta HTTP 200 OK
});
app.Run();

internal class Categoria
{
    public int Id { get; set; }
    public string Name { get; set; }
}
