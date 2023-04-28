using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPatternTest.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Prontuario { get; set; }
        [Required]
        public string Diagnostico { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
