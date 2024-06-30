using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaATM
{
    public class Deposito : Transaccion
    {
        private decimal monto;
        private Teclado teclado;
        private RanuraDeposito ranuraDeposito;
        private const int CANCELO = 0;
        public Deposito(int numeroCuentaUsuario, Pantalla pantallaATM,
        BaseDatosBanco baseDatosBancoATM, Teclado tecladoATM,
        RanuraDeposito ranuraDepositoATM)
: base(numeroCuentaUsuario, pantallaATM, baseDatosBancoATM)
        {
            teclado = tecladoATM;
            ranuraDeposito = ranuraDepositoATM;
        }
        public override void Ejecutar()
        {
            monto = PedirMontoADepositar();
            if (monto != CANCELO)
            {
                PantallaUsuario.MostrarMensaje(
                "\nIntroduzca un sobre de depósito que contenga ");
                PantallaUsuario.MostrarMontoEnDolares(monto);
                PantallaUsuario.MostrarLineaMensaje(" en la ranura para depósitos.");
                bool sobreRecibido = ranuraDeposito.SeRecibioSobreDeposito();

                if (sobreRecibido)
                {
                    PantallaUsuario.MostrarLineaMensaje(
                    "\nSe recibió su sobre.\n" +
                    "El dinero que acaba de depositar no estará disponible " +
                    "sino hasta que \nverifiquemos el monto del efectivo " +
                    "dentro del sobre, y que se haya verificado cualquier cheque incluido.");
                    BaseDatos.Abonar(NumeroCuenta, monto);
                }
                else
                    PantallaUsuario.MostrarLineaMensaje(
                    "\nNo insertó un sobre, por lo que el ATM ha " +
                    "cancelado su transacción.");
            } 
            else
                PantallaUsuario.MostrarLineaMensaje("\nCancelando la transacción...");
        }
        private decimal PedirMontoADepositar()
        {
            PantallaUsuario.MostrarMensaje("\nIntroduzca un monto a depositar en CENTAVOS (o 0 para cancelar): ");
            int entrada = teclado.ObtenerEntrada();
            if (entrada == CANCELO)
                return CANCELO;
            else
                return entrada / 100.00M;
        }
    }
}
