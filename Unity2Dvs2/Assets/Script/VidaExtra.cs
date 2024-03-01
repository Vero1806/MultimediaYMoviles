using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaExtra : MonoBehaviour
{

    [SerializeField] private AudioClip vidaExtraSonido;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControladorSonidos.Instance.EjecutarSonido(vidaExtraSonido);
            Destroy(this.gameObject);

        }
    }
}
