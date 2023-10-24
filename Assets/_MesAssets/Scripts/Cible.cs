using UnityEngine;

public class Cible : MonoBehaviour
{
    public float sante = 10f;

    public void RecevoirDegats(float quantite)
    {
        if (sante <= 0f)
        {
            Mourir();
        }
    }

    private void Mourir()
    {
        Destroy(gameObject);
    }
}
