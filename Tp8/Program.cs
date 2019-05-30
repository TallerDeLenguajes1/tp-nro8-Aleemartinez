using System;
using System.IO;

namespace tp7
{
    class Program
    {

        static void Main(string[] args)
        {
            int cant = 7;
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

            FileStream fs = new FileStream(nombrearch+extension, FileMode.Open, FileAccess.Write);
            usuario.guardar(nombrearch+extension, cant, fs);
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Elija la unidad donde desea realizar la copia de seguridad");
            int cont = 0;
            foreach (string drive in drives)
            {
                Console.Write(cont + ": ");
                Console.WriteLine(drive);
                cont++;
            }

            cant = int.Parse(Console.ReadLine());
            Console.WriteLine("Usted eligio la direccion de " + drives[cant]);
            string ruta2 = drives[cant] + @"BackUpAgenda\";
            if (!Directory.Exists(ruta2))
            {
                Directory.CreateDirectory(ruta2);
            }
            string ruta3 = ruta2 + nombrearch+extension;
           
            if (File.Exists(ruta3))
            {
                ruta3= ruta2 + @"\" + nombrearch +"copia"+DateTime.Now.ToString("dd_MM_mm")+ extension;
                File.Copy(nombrearch + extension, ruta3, false);
                File.Move(ruta3, ruta2 + nombrearch +DateTime.Now.ToString("dd_MM_mm")+".bk");
                Console.WriteLine("Creado correctamente");
            }
            else
            {
                File.Copy(nombrearch + extension, ruta3, false);
                File.Move(ruta3, ruta2 + nombrearch + ".bk");
                Console.WriteLine("Creado correctamente");
            }

            

        }
    }
}
