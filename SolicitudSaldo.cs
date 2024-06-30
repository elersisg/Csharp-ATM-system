using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaATM
{
    public class SolicitudSaldo : Transaccion
    {
        public SolicitudSaldo(int numeroCuentaUsuario, Pantalla pantallaATM, BaseDatosBanco baseDatosBancoATM) :
            base(numeroCuentaUsuario, pantallaATM, baseDatosBancoATM)
        { }

        public override void Ejecutar()
        {
            decimal saldoDisponible =
            BaseDatos.ObtenerSaldoDisponible(NumeroCuenta);
            decimal saldoTotal = BaseDatos.ObtenerSaldoTotal(NumeroCuenta);
            PantallaUsuario.MostrarLineaMensaje("\nInformación del saldo:");
            PantallaUsuario.MostrarMensaje(" - Saldo disponible: ");
            PantallaUsuario.MostrarMontoEnDolares(saldoDisponible);
            PantallaUsuario.MostrarMensaje("\n - Saldo total: ");
            PantallaUsuario.MostrarMontoEnDolares(saldoTotal);
            PantallaUsuario.MostrarLineaMensaje("");
        }
    }
}
