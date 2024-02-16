using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoVigilancia : MonoBehaviour
{
    public float velo;
    public float dist;
    private Vector2 starPosition;
     // Start is called before the first frame update
    void Start()
    {
        starPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movimiento = Mathf.Sin(Time.time * velo) * dist;
        transform.position = new Vector2(starPosition.x + movimiento, transform.position.y);
    }
}
