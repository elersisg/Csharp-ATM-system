using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaATM
{
    internal class DISPENSADOREFECTIVO
    {
        private int cuentaBilletes = 500;
    }
    public class DispensadorEfectivo
    {
        private const int CUENTA_INICIAL = 500;
        private int cuentaBilletes;
        public DispensadorEfectivo()
        {
            cuentaBilletes = CUENTA_INICIAL;
        }
        public void DispensarEfectivo(decimal monto)
        {
            int billetesRequeridos = ((int)monto) / 20;
            cuentaBilletes -= billetesRequeridos;
        }
        public bool HaySuficienteEfectivoDisponible(decimal monto)
        {
            int billetesRequeridos = ((int)monto) / 20;
            return (cuentaBilletes >= billetesRequeridos);
        }
    }
}
