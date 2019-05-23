using System;

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
            DateTime fechaini ;
            DateTime fechafin ;
            Random numrdm = new Random();
            Empleado estructura = new Empleado();
            ape = Convert.ToString((Apellidos)numrdm.Next(10));
            estado = Convert.ToString((Estc)numrdm.Next(2));
            carg = Convert.ToString((Cargo)numrdm.Next(5));
            gen = Convert.ToString((Gen)numrdm.Next(2));
            if (gen == "Masculino")
            {
                nom = Convert.ToString((Nombres)numrdm.Next(5));
            }
            else
            {
                nom = Convert.ToString((Nombres)numrdm.Next(5, 10));
            }
            if (gen == "Masculino")
            {
                 fechaini = new DateTime(1955, 1, 1);
                 fechafin = new DateTime(1994, 12, 31);
            }
            else
            {
                 fechaini = new DateTime(1960, 1, 1);
                 fechafin = new DateTime(1994, 12, 31);
                estado = estado.Replace("ro", "ra");
                estado = estado.Replace("do", "da");
                carg = carg.Replace("ro", "ra");
            }
            
            
            diferencia = fechafin.Day - fechaini.Day;
            fechaini.AddDays(numrdm.Next(diferencia));
            //if (mes == 2)
            //{
            //    dia = numrdm.Next(1, 29);
            //}
            //else if (año % 4 == 0 && año % 100 != 0 && año % 400 == 0 && mes == 2)
            //{
            //    dia = numrdm.Next(1, 30);
            //}
            //else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            //{
            //    dia = numrdm.Next(1, 31);
            //}
            //else
            //{
            //    dia = numrdm.Next(1, 32);
            //}

                fechaini = new DateTime(1980, 1, 1);
                fechafin = new DateTime(1994, 12, 31);
                diferencia = fechafin.Day - fechaini.Day;
                fechaini.AddDays(numrdm.Next(diferencia));
                emp.nombre = nom;
                emp.apellido = ape;
                emp.cargo = carg;
                emp.fechadenac = fechaini;
                emp.estadocivil = estado;
                emp.genero = gen;

                emp.fechaing = fechaini;
                emp.basico = 15000;
                emp.id = id1;

            return emp;
            }

            public float salario()
            {
                float salario;
                float adicion;
                int antiguedad, hijos = 0;

                DateTime hoy = DateTime.Today;
                antiguedad = hoy.Year -  fechaing.Year;
                if (estadocivil == "Casado")
                {
                    Random a = new Random();
                    hijos = a.Next(5);
                }



                adicion = adicional( basico, antiguedad,  cargo, hijos);
                salario =  basico + adicion;
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
                    adicion = (basico * 0.2F) * antiguedad;
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
        
  

    private Empleado inicio, final;

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
            int edad, añosjubilacion;
            DateTime hoy = DateTime.Today;
            edad = hoy.Year - empleado.fechadenac.Year;
            Console.WriteLine("Nombre: " + empleado.nombre);
            Console.WriteLine("Apellido: " + empleado.apellido);
            Console.WriteLine("Estado Civil: " + empleado.estadocivil);
            Console.WriteLine("Cargo: " + empleado.cargo);
            Console.WriteLine("Edad: {0} años", edad);
            Console.WriteLine("Salario: " + empleado.salario());
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
            int edad, contador = 0, añosjubilacion;
            float salariototal = 0;
            DateTime hoy = DateTime.Today;
            while (reco != null)
            {

                edad = hoy.Year - reco.fechadenac.Year;
                Console.WriteLine("ID: " + reco.id);
                Console.WriteLine("Nombre: " + reco.nombre);
                Console.WriteLine("Apellido: " + reco.apellido);
                Console.WriteLine("Estado Civil: " + reco.estadocivil);
                Console.WriteLine("Cargo: " + reco.cargo);
                Console.WriteLine("Edad: {0} años", edad);
                Console.WriteLine("Salario: " + reco.salario());
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

                salariototal += reco.salario();
                contador++;
                Console.WriteLine("\n");

                reco = reco.sig;
            }

            Console.WriteLine("\nSalario Total: " + salariototal + "; En un total de " + contador + " empleados");

        }



    }
}
