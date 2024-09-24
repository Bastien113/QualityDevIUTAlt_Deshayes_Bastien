using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace BiblioMedias
{
    public class Library
    {
        private List<Media> mediaCollection = new List<Media>();

        public Media this[int index]
        {
            get { return mediaCollection[index]; }
            set { mediaCollection[index] = value; }
        }

        public void SauvegarderBibliotheque(string fichier)
        {
            string json = JsonSerializer.Serialize(mediaCollection);
            File.WriteAllText(fichier, json);
        }

        public void ChargerBibliotheque(string fichier)
        {
            string json = File.ReadAllText(fichier);
            mediaCollection = JsonSerializer.Deserialize<List<Media>>(json);
        }

        public void AjouterMedia(Media media)
        {
            mediaCollection.Add(media);
        }

        public void RetirerMedia(Media media)
        {
            mediaCollection.Remove(media);
        }

        public void EmprunderMedia(Media media, string utilisateur)
        {
            if (media.NombreExemplairesDisponibles > 0)
            {
                media.NombreExemplairesDisponibles--;
                // Enregistrer les détails de l'emprunt
            }
            else
            {
                throw new Exception($"Le média '{media.Titre}' n'est pas disponible pour l'emprunt.");
            }
        }

        public void RetournerMedia(Media media, string utilisateur)
        {
            media.NombreExemplairesDisponibles++;
            // Mettre à jour les enregistrements d'emprunt
        }

        public List<Media> RechercherMediaParTitreOuAuteur(string critere)
        {
            return mediaCollection.Where(m => m.Titre.Contains(critere) || (m is Livre livre && livre.Auteur.Contains(critere))).ToList();
        }

        public List<Media> ListerMediasEmpruntes(string utilisateur)
        {
            // Implémenter la méthode en gardant une trace des emprunts
            throw new NotImplementedException();
        }

        public void AfficherStatistiques()
        {
            int totalMedias = mediaCollection.Count;
            int mediasPretesTotal = mediaCollection.Sum(m => m.NombreExemplairesDisponibles - m.NombreExemplairesDisponibles);
            int mediasDisponiblesTotal = mediaCollection.Sum(m => m.NombreExemplairesDisponibles);

            Console.WriteLine($"Nombre total de médias : {totalMedias}");
            Console.WriteLine($"Nombre total de médias empruntés : {mediasPretesTotal}");
            Console.WriteLine($"Nombre total de médias disponibles : {mediasDisponiblesTotal}");
        }
    }


}
