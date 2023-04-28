using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternTest.Interfaces;
using RepositoryPatternTest.Models;
using RepositoryPatternTest.Repositories;
using RepositoryPatternTest.Services;

var builder = WebApplication.CreateBuilder(args);

//Configurando o contexto do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Temos que adcionar o MVC.
builder.Services.AddMvc();

//Injeção de Independencia
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_HOSPITAL");
    });
}

app.UseHttpsRedirection();

//Criando os EndPoints
app.MapGet("/Paciente/{id}", ([FromRoute] int id, [FromServices] IRepository<Paciente> paciente) => 
{
    PacienteService pacienteService = new PacienteService(paciente);
    return Results.Ok(pacienteService.GetPacienteById(id));
});

app.MapGet("/Pacientes", ([FromServices] IRepository<Paciente> paciente) =>
{
    PacienteService pacienteService = new PacienteService(paciente);
    return Results.Ok(pacienteService.GetAll());
});

app.MapPost("/Paciente",([FromBody] Paciente model, [FromServices] IRepository<Paciente> paciente)=>
{
    PacienteService pacienteService = new PacienteService(paciente);
    pacienteService.AddPaciente(model);
    return Results.Created($"/pacientes/{model.Id}", model.Id);
});

app.MapPut("/Atualizar Paciente", ([FromBody] Paciente model, [FromServices] IRepository<Paciente> paciente) =>
{
    PacienteService pacienteService = new PacienteService(paciente);
    pacienteService.AtualizarPaciente(model);
    return Results.Ok($"/pacientes/{model.Id}");
});

app.MapDelete("/Deletar Paciente", ([FromBody] Paciente model, [FromServices] IRepository<Paciente> paciente) =>
{
    PacienteService pacienteService = new PacienteService(paciente);
    pacienteService.DeletarPaciente(model);
    return Results.Ok(pacienteService.GetAll());
});

//app.MapDelete("/Deletar Paciente/{id}", ([FromRoute] int id, [FromServices] IRepository<Paciente> paciente) =>
//{
//    PacienteService pacienteService = new PacienteService(paciente);
//    pacienteService.DeletarPaciente(id);
//    return Results.Ok(pacienteService.GetAll());
//});


app.Run();

