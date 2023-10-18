using UnityEngine;
using UnityEngine.InputSystem;

public class GestionFusil : MonoBehaviour
{
    // Quantit� de d�g�ts que le fusil peut causer.
    public float quantiteDegats = 10f;

    // Distance maximale � laquelle le fusil peut toucher une cible.
    public float porteeTir = 100f;

    // La cam�ra � travers laquelle le joueur vise et tire.
    public Camera cameraJoueur;

    // L'action associ�e au d�clenchement du tir.
    private InputAction actionTir;

    private void Start()
    {
        InitialiserActionTir();
    }

    // Configure l'action de tir pour le bouton gauche de la souris.
    private void InitialiserActionTir()
    {
        actionTir = new InputAction("Tir", binding: "<Mouse>/leftButton");
        actionTir.performed += context => EffectuerTir();
        actionTir.Enable();
    }

    // G�re le tir du fusil.
    private void EffectuerTir()
    {
        RaycastHit infoImpact;
        Vector3 origineTir = cameraJoueur.transform.position;
        Vector3 directionTir = cameraJoueur.transform.forward;

        // V�rifie si le tir a touch� une cible dans la port�e d�finie.
        bool aToucheCible = Physics.Raycast(origineTir, directionTir, out infoImpact, porteeTir);

        if (aToucheCible)
        {
            GererImpact(infoImpact);
        }
    }

    // G�re les cons�quences d'un tir r�ussi.
    private void GererImpact(RaycastHit infoImpact)
    {
        // Affiche le nom de l'objet touch� dans la console.
        Debug.Log(infoImpact.transform.name);

        // V�rifie si l'objet touch� a un composant 'Cible'.
        Cible cibleTouchee = infoImpact.transform.GetComponent<Cible>();

        // Si l'objet touch� est une 'Cible', inflige des d�g�ts.
        if (cibleTouchee != null)
        {
            cibleTouchee.RecevoirDegats(quantiteDegats);
        }
    }
}
