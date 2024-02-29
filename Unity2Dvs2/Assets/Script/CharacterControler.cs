using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControler : MonoBehaviour
{
    public float speed;
    float inputMovement;
    Rigidbody2D rigidBody;
    public bool isLookingRight;
    private float jumpSpeed = 10f;


    public int jumpsNums = 0;
    private BoxCollider2D boxCollider;
    public bool isJumping;
    
    public bool arregloSalto;
    public LayerMask surfaceLayer;

    public bool isRunning;
    private Animator animator;
    
    //Sonido
    private AudioSource audioSource;
    public AudioClip jumpClip;

    //Vidas
    Vidas Vida;
    private int vidas = 3;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
             surfaceLayer //Layer mask
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
            isJumping = true;
            animator.SetBool("isJumping", arregloSalto);
            audioSource.PlayOneShot(jumpClip);

        }

        if (arregloSalto)
        {
            jumpsNums = 0;
            isJumping = false;
        }
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
            // Respawn();
            PerderVida();
        }
        if (collision.gameObject.tag == "Vida")
        {
            RecuperarVida();
        }
    }
    void Respawn()
    {
        SceneManager.LoadScene(0);
        Debug.Log("You Dead. Try again");

    }

    void PerderVida()
    {
        vidas -= 1;

        if (vidas == 0)
        {
            // Reiniciamos el nivel.
            Respawn();
        }

        Vida.DesactivarVida(vidas);
    }

    bool RecuperarVida()
    {
        if (vidas == 3)
        {
            return false;
        }

        Vida.ActivarVida(vidas);
        vidas += 1;
        return true;
    }
}
