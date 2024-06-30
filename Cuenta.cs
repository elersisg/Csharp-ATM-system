using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaATM
{
    public class Cuenta
    {
        private int numeroCuenta;
        private int nip;
        private decimal saldoDisponible;
        private decimal saldoTotal;

        public Cuenta(int elNumeroCuenta, int elNIP,
        decimal elSaldoDisponible, decimal elSaldoTotal)
        {
            numeroCuenta = elNumeroCuenta;
            nip = elNIP;
            saldoDisponible = elSaldoDisponible;
            saldoTotal = elSaldoTotal;
        }
        public int NumeroCuenta
        {
            get
            {
                return numeroCuenta;
            }
        }
        public decimal SaldoDisponible
        {
            get
            {
                return saldoDisponible;
            }
        }
        public decimal SaldoTotal
        {
            get
            {
                return saldoTotal;
            }
        }
        public bool ValidarNIP(int NIPUsuario)
        {
            return (NIPUsuario == nip);
        }
        public void Abonar(decimal monto)
        {
            saldoTotal += monto;
        }
        public void Cargar(decimal monto)
        {
            saldoDisponible -= monto;
            saldoTotal -= monto;
        }
    }
}
