using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GunShot gunShot;

    public float moveSpeed;
    public float jumpForce;
    public float fuel = 1;
    public float maxfuel = 1;
    public float thrustForce;

    private bool isJumping;
    public bool isGrounded;
    private bool isflying;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayer;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalmovement;


    public Slider slider;

    private void Update() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);

        horizontalmovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // commande de saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        else if(isGrounded == false)
        {
            isJumping = false;
        }
        // commande de vol
        if (isGrounded == false && fuel > 0.3f && Input.GetButton("Jump"))
        {
            fuel = fuel -1f;
            isflying = true;
        }      
        else if (Input.GetButton("Jump") == false)
        {
            isflying = false;
        }      
        else if (fuel < 0.3f)
        {
            isflying = false;
        }      
        else if (isGrounded == true)
        {
            isflying = false;
        }


        Flip(rb.velocity.x);


        if (isGrounded == true && fuel < maxfuel)
        {
            fuel = fuel +1f;
        }

        //transforme le chiffre en son absolut
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        //animation de marche/attente
        animator.SetFloat("Speed", characterVelocity);
        //animation de vol
        animator.SetBool("IsFlying", isflying);
        animator.SetBool("IsGrounded", isGrounded);
        //animation de saut
        animator.SetBool("IsJumping", isJumping);

        slider.value = fuel;

    }

    void Start()
    {
        fuel = maxfuel;
    }

    void FixedUpdate()
    {
        MovePlayer(horizontalmovement);
    }

    void MovePlayer(float _horizontalmovement)
    {
        Vector3 targetvelocity = new Vector2(_horizontalmovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetvelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        if (isflying == true)
        {
            rb.AddForce(new Vector2(0f, thrustForce));     
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tank"))
        {
            fuel = maxfuel;
            slider.value = 1000;
        }
        if (collision.CompareTag("ammo"))
        {
            gunShot.reload = gunShot.maxreload;
        }
    } 

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}                 