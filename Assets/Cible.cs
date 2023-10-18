using UnityEngine;

public class Cible : MonoBehaviour
{
    // La sant� initiale de la cible.
    public float sante = 10f;

    // M�thode appel�e pour infliger des d�g�ts � la cible.
    public void RecevoirDegats(float quantite)
    {
        sante -= quantite; // R�duit la sant� de la cible en fonction de la quantit� de d�g�ts.

        // V�rifie si la sant� de la cible est �puis�e ou n�gative.
        if (sante <= 0f)
        {
            Mourir();
        }
    }

    // M�thode pour g�rer la "mort" de la cible.
    private void Mourir()
    {
        // D�truit l'objet associ� � la cible dans la sc�ne.
        Destroy(gameObject);
    }
}
