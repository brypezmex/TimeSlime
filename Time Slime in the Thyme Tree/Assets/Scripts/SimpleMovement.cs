using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SimpleMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private Animator anim;
    private bool grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // Grab refrences to rigidbody and animator from object
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        // flip player when moving left or right
        if(horizontalInput > 0.01f) {
            transform.localScale = new Vector3(3, 3, 1);
        } else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-3, 3, 1);
        if(Input.GetKey(KeyCode.Space) && grounded) {
            Jump();
        }

        //set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump() {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed * 2);
        anim.SetTrigger("jump");
        
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground") 
            anim.SetTrigger("landed");
            grounded = true;
    }
}
