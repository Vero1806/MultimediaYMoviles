using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TriggerPinnas : MonoBehaviour
{
    public score puntosPinnas;
    [SerializeField] private AudioClip fruta1;


   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControladorSonidos.Instance.EjecutarSonido(fruta1);
            puntosPinnas.totalScore += 10;
            Destroy(this.gameObject);
            
        }
    }
}
