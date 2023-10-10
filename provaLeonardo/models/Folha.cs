namespace provaLeonardo.models
{
    public class Folha
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public int Quantidade { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int FuncionarioId { get; set; }

        public virtual Funcionario? Funcionario { get; set; }
    }
}