using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaATM
{
    internal class BASEDATOSBANCO
    {

    }
    public class BaseDatosBanco
    {
        private Cuenta[] cuentas;
        public BaseDatosBanco()
        {
            cuentas = new Cuenta[2];
            cuentas[0] = new Cuenta(1016, 0417, 1000.00M, 1200.00M);
            cuentas[1] = new Cuenta(7418, 8529, 200.00M, 200.00M);
        }
        private Cuenta ObtenerCuenta(int numeroCuenta)
        {
            foreach (Cuenta cuentaActual in cuentas)
            {
                if (cuentaActual.NumeroCuenta == numeroCuenta)
                    return cuentaActual;
            }
            return null;
        }
        public bool AutenticarUsuario(int numeroCuentaUsuario, int NIPUsuario)
        {
            Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);
            if (cuentaUsuario != null)
                return cuentaUsuario.ValidarNIP(NIPUsuario);
            else
                return false;
        }
        public decimal ObtenerSaldoDisponible(int numeroCuentaUsuario)
        {
            Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);
            return cuentaUsuario.SaldoDisponible;
        }
        public decimal ObtenerSaldoTotal(int numeroCuentaUsuario)
        {
            Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);
            return cuentaUsuario.SaldoTotal;
        }
        public void Abonar(int numeroCuentaUsuario, decimal monto)
        {
            Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);
            cuentaUsuario.Abonar(monto);
        }
        public void Cargar(int numeroCuentaUsuario, decimal monto)
        {
            Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);
            cuentaUsuario.Cargar(monto);
        }
    }
}
