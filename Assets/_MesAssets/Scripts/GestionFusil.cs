using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class GestionFusil : MonoBehaviour
{

    public float domage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    [SerializeField] private InputActionAsset _actionAsset = default;

    void Update()
    {

        var fireAction = _actionAsset.FindAction("Fire");
        fireAction.performed += Shoot;
        fireAction.Enable();

    }

    void Shoot(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Cible cible = hit.transform.GetComponent<Cible>();
            if (cible != null)
            {
                cible.RecevoirDegats(domage);
            }
        }
    }

}
