using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GestionFusil : MonoBehaviour
{
    [SerializeField] public Transform raycastSpawnPoint;
    [SerializeField] private AudioSource _son = default;


    RaycastHit frappe;

    bool boutton = false;
    public void Update()
    {

        if (Physics.Raycast(raycastSpawnPoint.position, raycastSpawnPoint.forward, out frappe, 10f) && (boutton == true))
        {
            Debug.Log("JE TIRE");

            if (frappe.collider.CompareTag("Ballon"))
            {
                Destroy(frappe.collider.gameObject);
                Debug.Log("+1");
                _son.Play();
            }
            boutton = false;
        }
    }

    public void Tirer()
    {
        Debug.Log("J'appuie sur le bouton");
        boutton = true;
        Ray rayonTir = new Ray(raycastSpawnPoint.position, raycastSpawnPoint.forward);
        Debug.DrawRay(rayonTir.origin, rayonTir.direction * 10f, Color.red, 1f);


    }

}
