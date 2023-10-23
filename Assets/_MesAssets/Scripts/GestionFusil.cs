using UnityEngine;
using UnityEngine.InputSystem;

public class GestionFusil : MonoBehaviour
{
    public float quantiteDegats = 10f;

    public float distance = 100f;

    public Camera cameraJoueur;

    private InputAction actionTir;

    [SerializeField]Ray rayon = new Ray();

    private void Start()
    {
        InitialiserActionTir();
    }

    private void InitialiserActionTir()
    {
        actionTir = new InputAction("Tir", binding: "<Mouse>/leftButton");
        actionTir.performed += context => EffectuerTir();
        actionTir.Enable();
    }

    private void EffectuerTir()
    {
        RaycastHit infoImpact;
        Vector3 origineTir = cameraJoueur.transform.position;
        Vector3 directionTir = cameraJoueur.transform.forward;

        bool aToucheCible = Physics.Raycast(origineTir, directionTir, out infoImpact, distance);

        if (aToucheCible)
        {
            GererImpact(infoImpact);
        }
    }

    private void GererImpact(RaycastHit infoImpact)
    {
        Debug.Log(infoImpact.transform.name);

        Cible cibleTouchee = infoImpact.transform.GetComponent<Cible>();

        if (cibleTouchee != null)
        {
            cibleTouchee.RecevoirDegats(quantiteDegats);
        }
    }
}
