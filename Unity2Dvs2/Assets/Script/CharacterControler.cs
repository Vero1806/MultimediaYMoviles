using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float speed;
    float inputMovement;
    Rigidbody2D rigidBody;
    public bool isLookingRight;
    private float jumpSpeed = 10f;


    public int jumpsNums = 0;
    private BoxCollider2D boxCollider;
    
    public bool arregloSalto;
    public LayerMask surfaceLayer;

    public bool isRunning;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessingMovement();
        arregloSalto = CheckingFloor();
        ProcessingJump();
    }
    bool CheckingFloor()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
             boxCollider.bounds.center, //Origen de la caja
             new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), //Tamaño
             0f, //Ángulo
             Vector2.down, //Direccion hacia la que va la caja
             0.2f, //Distancia a la que aparece la caja
             surfaceLayer//Layer mask
             );
        return raycastHit.collider != null; //Devuelvo un valor siempre que no sea nulo
    }


    void ProcessingMovement()
    {
        //Movement logic
        inputMovement = Input.GetAxis("Horizontal");

        //Animation
        isRunning = inputMovement != 0 ? true : false;
        animator.SetBool("isRunning", isRunning);


        rigidBody.velocity = new Vector2(inputMovement * speed, rigidBody.velocity.y);
        CharacterOrientation(inputMovement);
    }
    void ProcessingJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (arregloSalto || jumpsNums < 1))
        {
            rigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumpsNums++;

        }

        if (arregloSalto) jumpsNums = 0;
    }


    void CharacterOrientation(float inputMovement)
    {
        if ((isLookingRight && inputMovement < 0) || (!isLookingRight && inputMovement > 0))
        {
            isLookingRight = !isLookingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pinchos")
        {
            Respawn();
        }
    }
    void Respawn()
    {
        this.transform.position = new Vector3(0,0,0);
        Debug.Log("You Dead. Try again");

    }

}
