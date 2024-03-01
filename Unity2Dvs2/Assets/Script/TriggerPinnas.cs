using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TriggerPinnas : MonoBehaviour
{
    public score puntos;
    [SerializeField] private AudioClip fruta1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControladorSonidos.Instance.EjecutarSonido(fruta1);
            puntos.totalScore += 10;
            Destroy(this.gameObject);
            
        }
    }
}
