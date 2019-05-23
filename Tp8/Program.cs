using System;

namespace tp7
{
    class Program
    {

        static void Main(string[] args)
        {
            int cant;
            Empleado usuario = new Empleado();
           
            cant = 5; //modificar para la cantidad que desea mostrar
            Console.WriteLine("Lista de {0} Empleados", cant);
            for (int i = 1; i <= cant; i++)
            {
                usuario.Insertar(i);
            }
            usuario.Imprimir();
            Console.WriteLine("\nElija usuario en especifico para mostrar");
            cant = int.Parse(Console.ReadLine());
            usuario.Imprimiruno(usuario.Extraer(cant));
        }
    }
}
