namespace fichero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Categoria> categorias = new List<Categoria>();
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\facubeltran\\Desktop\\reposgit\\bdt\\vv\\Categorias.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    int legajo= int.Parse(line.Substring(0,2));
                    string nombre= line.Substring(2,15);
                    double sueldo= double.Parse(line.Substring(17, 8));
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
                        legajo = $"00{rnd.Next(9)}{i}";
                        nombre = $"Juan Ramirez0{i} ";
                    }
                    else
                    {
                        legajo = $"0{rnd.Next(9)}{i}";
                        nombre = $"Juan Ramirez{i} ";
                    }

                    
                    string categoria = $"0{categorias[rnd.Next(4)].TipoCategoria}";
                    string cuenta = $"000{rand(9)}{rand(9)}{rand(9)}{rand(9)}";
                    //Write a line of text
                    sw.WriteLine($"{legajo}{nombre}{categoria}{cuenta}");
                    //Write a second line of text
                    
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

        private static int rand(int limite)
        {
            Random rnd = new Random();
            return rnd.Next(limite);
        }

    }
}