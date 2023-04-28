using RepositoryPatternTest.Interfaces;
using RepositoryPatternTest.Models;
using RepositoryPatternTest.Repositories;

namespace RepositoryPatternTest.Services
{
    public class PacienteService
    {
        //Criando uma propriedade que sera a comunicação da interface IRepository com a nossa classe
        //Paciente
        private readonly IRepository<Paciente> _pacienteRepository;

        public PacienteService(IRepository<Paciente> pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        //Metodos CRUD
        //Adicionar um paciente
        public void AddPaciente(Paciente paciente)
        {
            _pacienteRepository.Add(paciente);
        }

        //Atualizar um paciente
        public void AtualizarPaciente(Paciente paciente)
        {
            _pacienteRepository.Update(paciente);
        }

        //Deletar um paciente
        public void DeletarPaciente(Paciente paciente)
        {
            _pacienteRepository.Delete(paciente);
        }

        //Buscar paciente pelo ID
        public Paciente GetPacienteById(int id)
        {
            var pacienteId = _pacienteRepository.GetById(id);
            return pacienteId;
        }

        //Buscar todos os pacientes que temos salvo no nosso banco de dados
        public IEnumerable<Paciente> GetAll()
        {
            var todosPacientes = _pacienteRepository.GetAll();
            return todosPacientes;
        }

    }
}
