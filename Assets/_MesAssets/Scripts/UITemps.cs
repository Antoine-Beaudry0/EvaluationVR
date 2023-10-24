using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITemps : MonoBehaviour
{
    public TMP_Text tempsText; // R�f�rence au texte du chronom�tre
    public TMP_Text recordText; // R�f�rence au texte du record

    private float tempsEcoule = 0f; // Temps �coul� depuis le d�but
    private bool estActif = true; // Si le chronom�tre est actif ou non

    private int ballonsEclates = 0; // Nombre de ballons �clat�s
    private const int NOMBRE_BALLOONS = 18; // Nombre total de ballons � �clater
    private bool chronometreDemarre = false;
    public GestionFusil gestionFusil;


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
            ReactiverBallons();
        }
    }
    private void ReactiverBallons()
    {
        foreach (GameObject ballon in gestionFusil.ballons)
        {
            ballon.SetActive(true);
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
    public void Recommencer()
    {
        tempsEcoule = 0f; // R�initialise le temps �coul�
        ballonsEclates = 0; // R�initialise le nombre de ballons �clat�s
        estActif = true; // Active le chronom�tre
        chronometreDemarre = false; // Le chronom�tre attendra le premier ballon �clat� pour d�marrer

        // R�active tous les ballons
        foreach (GameObject ballon in gestionFusil.ballons)
        {
            ballon.SetActive(true);
        }

        // Met � jour l'affichage du temps
        AfficherTemps(tempsText, tempsEcoule);
    }


}
