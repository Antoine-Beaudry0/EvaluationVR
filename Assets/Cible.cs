using UnityEngine;

public class Cible : MonoBehaviour
{
    // La santé initiale de la cible.
    public float sante = 10f;

    // Méthode appelée pour infliger des dégâts à la cible.
    public void RecevoirDegats(float quantite)
    {
        sante -= quantite; // Réduit la santé de la cible en fonction de la quantité de dégâts.

        // Vérifie si la santé de la cible est épuisée ou négative.
        if (sante <= 0f)
        {
            Mourir();
        }
    }

    // Méthode pour gérer la "mort" de la cible.
    private void Mourir()
    {
        // Détruit l'objet associé à la cible dans la scène.
        Destroy(gameObject);
    }
}
