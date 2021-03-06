namespace project_school_api.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string DataNascimento { get; set; }

        public int ProfessorId { get; set; }
        
    }
}