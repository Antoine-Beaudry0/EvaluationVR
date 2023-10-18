using UnityEngine;
using UnityEngine.InputSystem;

public class GestionFusil : MonoBehaviour
{
    // Quantité de dégâts que le fusil peut causer.
    public float quantiteDegats = 10f;

    // Distance maximale à laquelle le fusil peut toucher une cible.
    public float porteeTir = 100f;

    // La caméra à travers laquelle le joueur vise et tire.
    public Camera cameraJoueur;

    // L'action associée au déclenchement du tir.
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

    // Gère le tir du fusil.
    private void EffectuerTir()
    {
        RaycastHit infoImpact;
        Vector3 origineTir = cameraJoueur.transform.position;
        Vector3 directionTir = cameraJoueur.transform.forward;

        // Vérifie si le tir a touché une cible dans la portée définie.
        bool aToucheCible = Physics.Raycast(origineTir, directionTir, out infoImpact, porteeTir);

        if (aToucheCible)
        {
            GererImpact(infoImpact);
        }
    }

    // Gère les conséquences d'un tir réussi.
    private void GererImpact(RaycastHit infoImpact)
    {
        // Affiche le nom de l'objet touché dans la console.
        Debug.Log(infoImpact.transform.name);

        // Vérifie si l'objet touché a un composant 'Cible'.
        Cible cibleTouchee = infoImpact.transform.GetComponent<Cible>();

        // Si l'objet touché est une 'Cible', inflige des dégâts.
        if (cibleTouchee != null)
        {
            cibleTouchee.RecevoirDegats(quantiteDegats);
        }
    }
}
