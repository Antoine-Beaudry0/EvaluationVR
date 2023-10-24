using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GestionFusil : MonoBehaviour
{
    [SerializeField] public Transform raycastSpawnPoint;
    [SerializeField] private AudioSource _son = default;
    public UITemps uiTemps;
    RaycastHit frappe;

    bool boutton = false;

    void Update()
    {
        Ray rayonTir = new Ray(raycastSpawnPoint.position, raycastSpawnPoint.forward);
        Debug.DrawRay(rayonTir.origin, rayonTir.direction * 10f, Color.red, 1f);
        if (Physics.Raycast(raycastSpawnPoint.position, raycastSpawnPoint.forward, out frappe, 10f) && (boutton == true))
        {
            Debug.Log("Tag détecté: " + frappe.collider.tag);
            if (frappe.collider.tag == "Ballon")
            {
                Debug.Log("----------------------Atteint----------------");
                Destroy(frappe.collider.gameObject);
                _son.Play();

                // Notifier le chronomètre
                uiTemps.BallonEclate();
            }

            boutton = false;
        }
    }

    public void Tirer()
    {
        boutton = true;
    }
}
