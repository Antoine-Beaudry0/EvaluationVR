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

    }

}
