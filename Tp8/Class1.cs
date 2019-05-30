using System;
using System.IO;

namespace tp7
{
    class Empleado

    {

            public Empleado sig;
            public string nombre;
            public string apellido;
            public DateTime fechadenac;
            public string estadocivil;
            public string genero;
            public DateTime fechaing;
            public float basico;
            public string cargo;
            public int id;



            private Empleado inicio, final;


            public enum Estc
            {
                Soltero, Casado
            }
            public enum Gen
            {
                Masculino, Femenino
            }
            public enum Cargo
            {
                Auxiliar, Administracion, Ingeniero, Especialista, Investigador
            }
            public enum Nombres
            {
                Santino, Alejandro, Bautista, Raul, Tiziano, Tatiana, Nancy, Brisa, Ema, Luz
            }
            public enum Apellidos
            {
                Perez, Martinez, Sanchez, Sosa, Valdez, Rojas, Alderetes, Carrizo, Fernandez, Roriguez
            }

      
        public Empleado llenar(Empleado emp, int id1)
        {
            int dia, mes, año, añoing;
            string nom, ape, gen, estado, carg;
            int diferencia;
            Random numrdm = new Random();
            DateTime fechaini ;
            DateTime fechafin ;
            DateTime hoy = DateTime.Today;
            Empleado estructura = new Empleado();
            ape = Convert.ToString((Apellidos)numrdm.Next(10));
            estado = Convert.ToString((Estc)numrdm.Next(2));
            carg = Convert.ToString((Cargo)numrdm.Next(5));
            gen = Convert.ToString((Gen)numrdm.Next(2));
            

            if (gen == "Masculino")
            {
                año = numrdm.Next(1955, 1995);
                añoing = numrdm.Next(año + 25, 2019);
                nom = Convert.ToString((Nombres)numrdm.Next(5));
            }
            else
            {
                año = numrdm.Next(1960, 1995);
                añoing = numrdm.Next(año + 25, 2019);
                nom = Convert.ToString((Nombres)numrdm.Next(5, 10));
                estado = estado.Replace("ro", "ra");
                estado = estado.Replace("do", "da");
                carg = carg.Replace("ro", "ra");
            }
            //if (gen == "Masculino")
            //{
            //     //fechaini = new DateTime(1955, 1, 1);
            //     //fechafin = new DateTime(1994, 12, 31);
            //}
            //else
            //{
            //     fechaini = new DateTime(1960, 1, 1);
            //     fechafin = new DateTime(1994, 12, 31);
            //    estado = estado.Replace("ro", "ra");
            //    estado = estado.Replace("do", "da");
            //    carg = carg.Replace("ro", "ra");
            //}
            mes = numrdm.Next(13);
            //mesing = numrdm.Next(13);
            

            //diferencia = fechafin.Day - fechaini.Day;
            //fechaini.AddDays(numrdm.Next(diferencia));
            

            //fechaini = new DateTime(1980, 1, 1);
            //    fechafin = new DateTime(1994, 12, 31);
            //    diferencia = fechafin.Day - fechaini.Day;
            //    fechaini.AddDays(numrdm.Next(0,diferencia));
                emp.nombre = nom;
                emp.apellido = ape;
                emp.cargo = carg;
                emp.fechadenac = fecha(año);
                emp.estadocivil = estado;
                emp.genero = gen;

                emp.fechaing = fecha(añoing);
                emp.basico = 15000;
                emp.id = id1;

            return emp;
            }

            public float salario(Empleado empleado)
            {
                float salario;
                float adicion;
                int hijos = 0;
            int antiguedad = 0;
            try
            {
                 antiguedad = DateTime.Today.AddTicks(-empleado.fechaing.Ticks).Year - 1;
            }
            catch (Exception)
            {
                 antiguedad = DateTime.Today.AddTicks(-empleado.fechaing.Ticks).Year - 2;
                throw;
            }
                
              
                
                if (empleado.estadocivil == "Casado" || empleado.estadocivil == "Casada")
                {
                    Random a = new Random();
                    hijos = a.Next(5);
                }



                adicion = adicional( empleado.basico, antiguedad,  empleado.cargo, hijos);
                salario =  empleado.basico + adicion;
                return salario;
            }

            public float adicional(float basico, int antiguedad, string cargo, int canthijos)
            {
                float adicion;
         
                
           
                if (antiguedad > 20)
                {
                    adicion = basico * 0.25F;
                }
                else
                {
                    adicion = (basico * 0.02F) * antiguedad;
                }
                if (cargo == "Ingeniero" || cargo == "Especialista")
                {
                    adicion = adicion * 1.5F;
                }
                if (canthijos > 2)
                {
                    adicion = adicion + 5000;
                }


                return adicion;
            }
        
  


        public Empleado()
        {
            inicio = null;
            final = null;
        }
        public bool Vacia()
        {
            if (inicio == null)
                return true;
            else
                return false;
        }


        public void Insertar(int id)
        {
            Empleado nuevo;
            nuevo = new Empleado();
            llenar(nuevo, id);
            
            nuevo.sig = null;
            if (Vacia())
            {
                inicio = nuevo;
                final = nuevo;
            }
            else
            {
                final.sig = nuevo;
                final = nuevo;
            }
        }
        public Empleado Extraer(int id)
        {
            Empleado empleado = inicio;
            Empleado ultimo = final;
            if (final.id >= id && empleado.id <= id)
            {
                while (empleado.id != id)
                {
                    empleado = empleado.sig;
                }
                return empleado;
            }
            else
            {
                Console.WriteLine("\nID no encontrado verifique e ingrese nuevamente");
                id = int.Parse(Console.ReadLine());
                return Extraer(id);

            }
        }
        public void Imprimiruno(Empleado empleado)
        {
            int añosjubilacion;
            DateTime hoy = DateTime.Today;
            int edad = DateTime.Today.AddTicks(-empleado.fechadenac.Ticks).Year - 1;
            Console.WriteLine("ID: " + empleado.id);
            Console.WriteLine("Nombre: " + empleado.nombre);
            Console.WriteLine("Apellido: " + empleado.apellido);
            Console.WriteLine("Fecha de nac: " + empleado.fechadenac.ToShortDateString());
            Console.WriteLine("Estado Civil: " + empleado.estadocivil);
            Console.WriteLine("Genero: " + empleado.genero);
            Console.WriteLine("Fecha de ingreso: " + empleado.fechaing.ToShortDateString());
            Console.WriteLine("Sueldo Basico: " + empleado.basico);
            Console.WriteLine("Cargo: " + empleado.cargo);
            Console.WriteLine("Edad: {0} años", edad);
            Console.WriteLine("Salario: " + salario(empleado));
            Console.Write("Años Para Jubilarse: ");
            if (empleado.genero == "Masculino")
            {
                añosjubilacion = 65 - edad;
            }
            else
            {
                añosjubilacion = 60 - edad;
            }
            Console.Write(añosjubilacion);
            Console.WriteLine("\n");

        }
        public void Imprimir()
        {
            Empleado reco = inicio;
            int  edad,contador = 0, añosjubilacion;
            float salariototal = 0;
            DateTime hoy = DateTime.Today;
            while (reco != null)
            {
                edad = DateTime.Today.AddTicks(-reco.fechadenac.Ticks).Year - 1;
                Console.WriteLine("ID: " + reco.id);
                Console.WriteLine("Nombre: " + reco.nombre);
                Console.WriteLine("Apellido: " + reco.apellido);
                Console.WriteLine("Fecha de nac: " + reco.fechadenac.ToShortDateString());
                Console.WriteLine("Estado Civil: " + reco.estadocivil);
                Console.WriteLine("Genero: " + reco.genero);
                Console.WriteLine("Fecha de ingreso: " + reco.fechaing.ToShortDateString());
                Console.WriteLine("Sueldo Basico: " + reco.basico);
                Console.WriteLine("Cargo: " + reco.cargo);
                Console.WriteLine("Edad: {0} años", edad);
                Console.WriteLine("Salario: " + salario(reco));
                Console.Write("Años Para Jubilarse: ");
                if (reco.genero == "Masculino")
                {
                   
                    añosjubilacion = 65 - edad;
                }
                else
                {
                    
                    añosjubilacion = 60 - edad;
                }
                Console.Write(añosjubilacion);

                salariototal += salario(reco);
                contador++;
                Console.WriteLine("\n");

                reco = reco.sig;
            }

            Console.WriteLine("\nSalario Total: " + salariototal + "; En un total de " + contador + " empleados");

        }
        public DateTime fecha(int año)
        {
            int mes,dia;
            Random numrdm = new Random();
            DateTime fecha1;
            mes = numrdm.Next(1, 13);



           if (año % 4 == 0 && año % 100 != 0 && mes == 2)
            {
                dia = numrdm.Next(1, 30);
            }
            else if  ( año % 100 == 0 && año % 400 ==0 && mes == 2)
            {
                dia = numrdm.Next(1,30);
            }
           else if(mes == 2)
            {
                dia = numrdm.Next(1, 29);
            }
            else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                dia = numrdm.Next(1, 31);
            }
            else
            {
                dia = numrdm.Next(1, 32);
            }
            fecha1 = new DateTime(año, mes, dia);

            if (fecha1 >= DateTime.Today)
            {
                fecha(año - 1);
            }
                return fecha1;


        }

        public Empleado[] arre(Empleado emp)
        {
            Empleado[] arre=new Empleado[90];
            arre[0]= emp;
            return arre;
        }
        public void guardar(string ruta, int cant, FileStream fs)
        {   
            
            Empleado[] datos = new Empleado[6];
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 1; i <= 5; i++)
            {
                cant++;
                Insertar(cant);
                fs.Seek(0, SeekOrigin.End);
                datos = arre(Extraer(cant));
                sw.WriteLine("Nombre: " + datos[0].nombre);
                sw.WriteLine("Apellido: " + datos[0].apellido);
                sw.WriteLine("Fecha de nac: " + datos[0].fechadenac);
                sw.WriteLine("Estado Civil: " + datos[0].estadocivil);
                sw.WriteLine("Fecha de ing: " + datos[0].fechaing);
                sw.WriteLine("Genero: " + datos[0].genero);
                sw.WriteLine("Salario: " + datos[0].salario(datos[0]) + " \n ");

            }
            sw.Close();
            fs.Close();

        }

    }
}
