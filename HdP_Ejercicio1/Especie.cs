using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoologico_Modelos
{
    public class Especie
    {
        [Key] public int codigo { get; set; }
        public string NombreComun { get; set; }

        //Navegation Property
        public List<Animal>? Animales { get; set; }

    }
}
