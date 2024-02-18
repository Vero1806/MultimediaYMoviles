using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoVigilancia : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] pointMovement;
    [SerializeField] private float minDistance;

    private int numAletorio;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        numAletorio = Random.Range(0, pointMovement.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Giro();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointMovement[numAletorio].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, pointMovement[numAletorio].position) < minDistance)
        {
            numAletorio = Random.Range(0, pointMovement.Length);
            Giro();
        }
    }
    private void Giro()
    {
        if (transform.position.x < pointMovement[numAletorio].position.x)
        {
            spriteRenderer.flipX = true;
        }

        else
        {
            spriteRenderer.flipX = false;
        }
    }

}
