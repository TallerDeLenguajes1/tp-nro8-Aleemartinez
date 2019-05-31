using System;
using System.IO;

namespace tp7
{
    class Program
    {

        static void Main()
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

            string nombrearch = "empleados";
            string extension = ".csv";
            string nombrecarpeta = @"BackUpAgenda\";
            FileStream fs = new FileStream(nombrearch+extension, FileMode.OpenOrCreate, FileAccess.Write);
            usuario.Guardar(cant, fs);

            string ruta2 = usuario.Elegirdisco() + nombrecarpeta;
            string destino = usuario.Crearcarpeta(ruta2) + nombrearch + DateTime.Now.ToString("dd_MM_mm") + extension;
            usuario.Mover(fs,destino);
           
            

            

        }
    }
}
