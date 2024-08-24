using System.Linq.Expressions;
using System.Reflection;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {   
        public Reserva() {}
        
        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

       public List<Pessoa> Hospedes { get; set; }
       public Suite Suite { get; set; }
       public int DiasReservados { get; set; }

       public void CadastrarHospedes(List<Pessoa> hospedes)
       {
            if(hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A quantidade de hóspedes não " +
                "pode exceder a capacidade da suíte.");
            }
       }

       public void CadastrarSuite(Suite suite)
       {
            Suite = suite;
       }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Capacity;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {   
                decimal desconto = 0.10M;
                valor = DiasReservados * Suite.ValorDiaria - (valor * desconto);
            }

            return valor;
        }   

    }
}