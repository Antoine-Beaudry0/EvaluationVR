using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GestionFusil : MonoBehaviour
{
    [SerializeField] public Transform raycastSpawnPoint;
    [SerializeField] private AudioSource _sonBallonEclate = default;
    [SerializeField] private AudioSource _sonCoupDeFeu = default;

    public UITemps uiTemps;
    RaycastHit frappe;
    public List<GameObject> ballons = new List<GameObject>();
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
                frappe.collider.gameObject.SetActive(false);
                _sonBallonEclate.Play();

                // Notifier le chronomètre
                uiTemps.BallonEclate();
            }

            boutton = false;
        }
    }

    public void Tirer()
    {
        _sonCoupDeFeu.Play();
        boutton = true;
    }
}
