using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioMedias
{
    public class Media
    {
        public string Titre { get; set; }
        public int NumeroReference { get; set; }
        public int NombreExemplairesDisponibles { get; set; }

        public static Media operator +(Media media, int quantite)
        {
            media.NombreExemplairesDisponibles += quantite;
            return media;
        }

        public static Media operator -(Media media, int quantite)
        {
            if (media.NombreExemplairesDisponibles < quantite)
                throw new Exception($"Nombre d'exemplaires disponibles insuffisant pour le média '{media.Titre}'");

            media.NombreExemplairesDisponibles -= quantite;
            return media;
        }
    }
}
