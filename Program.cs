using M12_NotasEf;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

using NotasDbContext db = new NotasDbContext();

Console.WriteLine("Conectando a notas.db");

if (!db.Estudiantes.Any())
{
    db.Estudiantes.Add(new Estudiante { Nombre = "Jhonny", Nota = 7, Ciudad = "Guayaquil" });
    db.Estudiantes.Add(new Estudiante { Nombre = "Pedro", Nota = 9, Ciudad = "Guayaquil" });
    db.Estudiantes.Add(new Estudiante { Nombre = "Alex", Nota = 8, Ciudad = "Quito" });
    db.Estudiantes.Add(new Estudiante { Nombre = "Luisa", Nota = 10, Ciudad = "Guayaquil" });

    int filas = db.SaveChanges(); // comando para guardar en la base de datos
    Console.WriteLine($"Filas insertadas: {filas}");
}

List<Estudiante> todos = db.Estudiantes.ToList();
Console.WriteLine($"Estudiantes en la base de datos: {todos.Count()}");

foreach (var estudiante in todos)
{
    Console.WriteLine($"{estudiante.Id}, {estudiante.Nombre}, {estudiante.Nota}, {estudiante.Ciudad}");
}

List<string> aprobados = db.Estudiantes
.Where(e => e.Nota > 7)
.OrderByDescending(e => e.Nota)
.Select(e => e.Nombre)
.ToList();
Console.WriteLine($"Aprovados: {string.Join(",", aprobados)}");
int deQuito = db.Estudiantes.Count(e => e.Ciudad == "Quito");
Console.WriteLine($"De Quito: {deQuito}");

IQueryable<Estudiante> consulta = db.Estudiantes.Where(e => e.Nota >= 7);
Console.WriteLine("Sql: ");
Console.WriteLine(consulta.ToQueryString());