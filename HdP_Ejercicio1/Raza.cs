using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoologico_Modelos
{
    public class Raza
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }

        //Navegation Property
        public List<Animal>? Animales { get; set; }
    }
}
