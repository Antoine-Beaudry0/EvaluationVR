using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITemps : MonoBehaviour
{
    public TMP_Text tempsText; // Référence au texte du chronomètre
    public TMP_Text recordText; // Référence au texte du record

    private float tempsEcoule = 0f; // Temps écoulé depuis le début
    private bool estActif = true; // Si le chronomètre est actif ou non

    private int ballonsEclates = 0; // Nombre de ballons éclatés
    private const int NOMBRE_BALLOONS = 18; // Nombre total de ballons à éclater
    private bool chronometreDemarre = false;


    private void Start()
    {
        float record = PlayerPrefs.GetFloat("Record", float.MaxValue);
        if (record != float.MaxValue)
        {
            AfficherTemps(recordText, record);
        }
    }

    private void Update()
    {
        if (estActif && chronometreDemarre)
        {
            tempsEcoule += Time.deltaTime;
            AfficherTemps(tempsText, tempsEcoule);
        }
    }


    private void AfficherTemps(TMP_Text text, float temps)
    {
        int minutes = (int)(temps / 60);
        int secondes = (int)(temps % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, secondes);
    }
    public void BallonEclate()
    {
        if (!chronometreDemarre)
        {
            chronometreDemarre = true;
        }

        ballonsEclates++;
        if (ballonsEclates >= NOMBRE_BALLOONS)
        {
            estActif = false;
            SauvegarderRecord();
        }
    }


    private void SauvegarderRecord()
    {
        float record = PlayerPrefs.GetFloat("Record", float.MaxValue);
        if (tempsEcoule < record)
        {
            PlayerPrefs.SetFloat("Record", tempsEcoule);
            AfficherTemps(recordText, tempsEcoule);
        }
    }

}
