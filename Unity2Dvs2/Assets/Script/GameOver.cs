using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TMP_Text pointText;

   public void Jugar (int puntos)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameObject.SetActive (true);
        pointText.text = "Puntuación fina = " + puntos.ToString();  
    }
}
