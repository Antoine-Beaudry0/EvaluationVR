using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GestionFusil : MonoBehaviour
{
    [SerializeField] public Transform raycastSpawnPoint;
    [SerializeField] private AudioSource _son = default;

    public float raycastDistance = 10f;

    RaycastHit frappe;

    bool boutton = false;
    public void Update()
    {
        Ray rayonTir = new Ray(raycastSpawnPoint.position, raycastSpawnPoint.forward);
        if (Physics.Raycast(rayonTir, out frappe, raycastDistance) && (boutton == true))
        {
            Debug.Log("RayCast");
            if (frappe.collider.CompareTag("Ballon"))
            {
                Debug.Log("Ca devrait fonctionner");
                Destroy(frappe.collider.gameObject);
                Debug.Log("+1");
                _son.Play();
            }
            boutton = false;
        }
    }

    public void Tirer()
    {
        Debug.Log("JE TIRE");
        boutton = true;

    }

}
