using BiblioMedias;

class Program
{
    static void Main(string[] args)
    {
        // Création de la bibliothèque et ajout de médias
        var library = new Library();
        library.AjouterMedia(new Livre { Titre = "Livre 1", NumeroReference = 1, NombreExemplairesDisponibles = 3, Auteur = "Auteur 1" });
        library.AjouterMedia(new DVD { Titre = "DVD 1", NumeroReference = 2, NombreExemplairesDisponibles = 2, Duree = 120 });
        library.AjouterMedia(new CD { Titre = "CD 1", NumeroReference = 3, NombreExemplairesDisponibles = 4, Artiste = "Artiste 1" });

        // 5.3. Affichage des informations de chaque média
        Console.WriteLine("Informations des médias dans la bibliothèque :");
        foreach (var media in library)
        {
            media.AfficherInfos();
        }

        try
        {
            library.EmprunderMedia(library[0], "Utilisateur 1");
            library.RetournerMedia(library[0], "Utilisateur 1");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();
    }
}