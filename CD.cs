using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioMedias
{
    public class CD : Media
    {
        public string Artiste { get; set; }

        public void AfficherInfos()
        {
            Console.WriteLine($"Titre: {Titre}, Numéro de référence: {NumeroReference}, Nombre d'exemplaires disponibles: {NombreExemplairesDisponibles}, Artiste: {Artiste}");
        }
    }
}
