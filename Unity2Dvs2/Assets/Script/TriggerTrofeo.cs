using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBandera : MonoBehaviour
{
    public score puntos;
    [SerializeField] private AudioClip trofeo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControladorSonidos.Instance.EjecutarSonido(trofeo);
            puntos.totalScore += 100;
             
        }
    }
}
