using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y);

        if(Input.GetKey(KeyCode.Space)) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
        }
    }
}
