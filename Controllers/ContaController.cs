using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciasBancariasDIO.Models;

namespace TransferenciasBancariasDIO.Controllers
{
    public class ContaController
    {
        private readonly Conta conta;

        public ContaController(Conta conta)
        {
            this.conta = conta;
        }

        public bool Sacar(double valorSaque)
        {
            if (conta.Saldo - valorSaque < (conta.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            conta.Saldo -= valorSaque;

            MostrarSaldoAtual(conta);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            conta.Saldo += valorDeposito;
            MostrarSaldoAtual(conta);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(valorTransferencia))
            {
                contaDestino.Saldo += valorTransferencia;
                MostrarSaldoAtual(contaDestino);
            }
        }

        public void MostrarSaldoAtual(Conta contaVerificar)
        {
            Console.WriteLine("Saldo atual da conta de {0} é {1}", contaVerificar.Nome, contaVerificar.Saldo);
        }

    }
}
