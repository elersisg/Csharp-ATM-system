﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaATM
{
    public class Retiro: Transaccion
    {
        private decimal monto;
        private Teclado teclado;
        private DispensadorEfectivo dispensadorEfectivo;
        private const int CANCELO = 6;
        public Retiro(int numeroCuentaUsuario, Pantalla pantallaATM,
        BaseDatosBanco baseDatosBancoATM, Teclado tecladoATM,
        DispensadorEfectivo dispensadorEfectivoATM)
        : base(numeroCuentaUsuario, pantallaATM, baseDatosBancoATM)
        {
            teclado = tecladoATM;
            dispensadorEfectivo = dispensadorEfectivoATM;
        }
        public override void Ejecutar()
        {
            bool efectivoDispensado = false;
            bool transaccionCancelada = false;
            do
            {
                int seleccion = MostrarMenuDeMontos();
                if (seleccion != CANCELO)
                {
                    monto = seleccion;
                    decimal saldoDisponible =
                    BaseDatos.ObtenerSaldoDisponible(NumeroCuenta);
                    if (monto <= saldoDisponible)
                    {
                        if (dispensadorEfectivo.HaySuficienteEfectivoDisponible(monto))
                        {
                            BaseDatos.Cargar(NumeroCuenta, monto);
                            dispensadorEfectivo.DispensarEfectivo(monto);
                            efectivoDispensado = true;
                            PantallaUsuario.MostrarLineaMensaje(
                            "\nPor favor tome su efectivo del dispensador.");
                        }
                        else
                            PantallaUsuario.MostrarLineaMensaje(
                            "\nNo hay suficiente efectivo disponible en el ATM." +
                            "\n\nPor favor elija un monto más pequeño.");
                    }
                    else
                        PantallaUsuario.MostrarLineaMensaje("\nNo hay suficiente efectivo disponible en su cuenta."
                            + "\n\nPor favor elija un monto más pequeño.");
                }
                else
                {
                    PantallaUsuario.MostrarLineaMensaje("\nCancelando la transacción...");
                    transaccionCancelada = true;
                }
            } while ((!efectivoDispensado) && (!transaccionCancelada));
        }
        private int MostrarMenuDeMontos()
        {
            int eleccionUsuario = 0;
            int[] montos = { 0, 20, 40, 60, 100, 200 };
            while (eleccionUsuario == 0)
            {
                PantallaUsuario.MostrarLineaMensaje("\nOpciones de retiro:");
                PantallaUsuario.MostrarLineaMensaje("1 - $20");
                PantallaUsuario.MostrarLineaMensaje("2 - $40");
                PantallaUsuario.MostrarLineaMensaje("3 - $60");
                PantallaUsuario.MostrarLineaMensaje("4 - $100");
                PantallaUsuario.MostrarLineaMensaje("5 - $200");
                PantallaUsuario.MostrarLineaMensaje("6 - Cancelar transacción");
                PantallaUsuario.MostrarMensaje(
                "\nElija una opción de retiro (1-6): ");
                int entrada = teclado.ObtenerEntrada();
                switch (entrada)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        eleccionUsuario = montos[entrada];
                        break;
                    case CANCELO:
                        eleccionUsuario = CANCELO;
                        break;
                    default:
                        PantallaUsuario.MostrarLineaMensaje(
                        "\nSelección inválida. Intente de nuevo.");
                        break;
                }
            }
            return eleccionUsuario;
        }
    }
}
