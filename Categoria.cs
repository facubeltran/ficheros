using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fichero
{
    internal class Categoria
    {
        int tipoCategoria;
        string nombre;
        double sueldo;

        public Categoria(int tipoCategoria, string nombre, double sueldo)
        {
            this.tipoCategoria = tipoCategoria;
            this.nombre = nombre;
            this.sueldo = sueldo;
        }

        public int TipoCategoria { get => tipoCategoria; set => tipoCategoria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Sueldo { get => sueldo; set => sueldo = value; }
    }
}
