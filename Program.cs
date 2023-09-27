namespace fichero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Categoria> categorias = new List<Categoria>();
            String line = "";
            leerCategorias(categorias, line);
            crearEmpleados(rnd, categorias);
            crearSueldosFichero(categorias, line);
        }

        private static string crearSueldosFichero(List<Categoria> categorias, string line)
        {
            try
            {

                string Empresa = "BANCO S INTERNACIONAL";
                string Cuenta = "2345532";
                int cantidadEmpleados = 0;
                double totalSueldo = 0;

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamReader srSueldos = new StreamReader("C:\\Users\\facubeltran\\Desktop\\reposgit\\bdt\\vv\\Empleados.txt");
                StreamWriter swSueldos = new StreamWriter("C:\\Users\\facubeltran\\Desktop\\reposgit\\bdt\\vv\\Sueldos.txt");
                swSueldos.WriteLine($"{Empresa};{Cuenta}");
                line = srSueldos.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    int cuenta = int.Parse(line.Substring(27, 7));
                    string nombre = line.Substring(4, 20);
                    int catInt = int.Parse(line.Substring(25, 2));
                    //write the line to console window
                    double sueldo = categorias.Find(sue => sue.TipoCategoria == catInt).Sueldo;


                    //DETALLE
                    swSueldos.WriteLine($"{cuenta};{nombre};{sueldo}");
                    ++cantidadEmpleados;
                    totalSueldo += sueldo;
                    line = srSueldos.ReadLine();


                }

                Categoria cat = categorias[rand(4)];
                double totalRedondeado = Math.Round(totalSueldo, 2);
                swSueldos.WriteLine($"{cantidadEmpleados};{totalRedondeado}");
                srSueldos.Close();
                swSueldos.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return line;
        }

        private static void crearEmpleados(Random rnd, List<Categoria> categorias)
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\Users\\facubeltran\\Desktop\\reposgit\\bdt\\vv\\Empleados.txt");
                for (int i = 0; i < 100; i++)
                {
                    string legajo;
                    string nombre;
                    if (i < 10)
                    {
                        legajo = $"00{rand(9)}{i}";
                        nombre = $"Juan Ramirez Gauss0{i} ";
                    }
                    else
                    {
                        legajo = $"0{rand(9)}{i}";
                        nombre = $"Juan Ramirez Gauss{i} ";
                    }

                    Categoria cat = categorias[rand(4)];
                    string categoriaT = $"0{cat.TipoCategoria}";
                    string cuenta = $"{rnd.Next(1, 9)}0{rand(9)}0{rand(9)}0{rand(9)}";
                    //Write a line of text
                    sw.WriteLine($"{legajo}{nombre}{categoriaT}{cuenta}");
                    //Close the file     
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private static string leerCategorias(List<Categoria> categorias, string line)
        {
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\facubeltran\\Desktop\\reposgit\\bdt\\vv\\Categorias.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    int legajo = int.Parse(line.Substring(0, 2));
                    string nombre = line.Substring(2, 15);
                    double sueldo = double.Parse(line.Substring(17, 8));
                    //write the line to console window                    
                    categorias.Add(new Categoria(legajo, nombre, sueldo));
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            foreach (Categoria cat in categorias)
            {
                Console.WriteLine($"Categoria:{cat.TipoCategoria}");
                Console.WriteLine($"Nombre:{cat.Nombre}");
                Console.WriteLine($"Sueldo:{cat.Sueldo}");
            }

            return line;
        }

        private static int rand(int limite)
        {
            Random rnd = new Random();
            return rnd.Next(limite);
        }

    }
}