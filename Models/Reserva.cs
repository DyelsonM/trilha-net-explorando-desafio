namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade da suíte é suficiente para os hóspedes
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else if (Suite == null)
            {
                throw new Exception("Não é possível cadastrar hóspedes sem uma suíte definida.");
            }
            else
            {
                throw new Exception("A suíte não comporta a quantidade de hóspedes informada.");
            }
        }
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes != null ? Hospedes.Count : 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new Exception("Não é possivel calcular o valor sem uma suíte cadastrada.");
            }
            //calcula o valor total da reserva
            decimal valor = DiasReservados * Suite.ValorDiaria;

            //aplica desconto de 10% se os dias reservados forem 10 ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; //desconto de 10%
            }

            return valor;
        }
    }
}