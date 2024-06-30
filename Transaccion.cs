using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaATM
{
    public abstract class Transaccion
    {
        private int numeroCuenta;
        private Pantalla pantallaUsuario;
        private BaseDatosBanco baseDatos;

        public Transaccion(int cuentaUsuario, Pantalla laPantalla, BaseDatosBanco laBaseDatos)
        {
            numeroCuenta = cuentaUsuario;
            pantallaUsuario = laPantalla;
            baseDatos = laBaseDatos;
        }
        public int NumeroCuenta
        {
            get
            {
                return numeroCuenta;
            }
        }
        public Pantalla PantallaUsuario
        {
            get
            {
                return pantallaUsuario;
            }
        }

        public BaseDatosBanco BaseDatos
        {
            get
            {
                return baseDatos;
            }
        }
        public abstract void Ejecutar();
    }
}
