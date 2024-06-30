using System;
public class Pantalla
{
    public void MostrarMensaje(string mensaje)
    {
        Console.Write(mensaje);
    }
    public void MostrarLineaMensaje(string mensaje)
    {
        Console.WriteLine(mensaje);
    }
    public void MostrarMontoEnDolares(decimal monto)
    {
        Console.Write("{0:C}", monto);
    }
}

